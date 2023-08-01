namespace Core.MessageQueue;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitMqClient : IDisposable
{
    private readonly Lazy<IModel> _channel;
    private readonly Lazy<IConnection> _connection;

    public RabbitMqClient(string hostname, string virtualHostname = "/")
    {
        _connection = new Lazy<IConnection>(() =>
        {
            var factory = new ConnectionFactory() { HostName = hostname, VirtualHost = virtualHostname };
            return factory.CreateConnection();
        });
        _channel = new Lazy<IModel>(() => _connection.Value.CreateModel());
    }

    public void Consume(string applicationName, string queueName, Action<string> action)
    {
        var consumer = new EventingBasicConsumer(_channel.Value);
        consumer.Received += (sender, e) => action(ConvertStreamToString(e.Body));
        _channel.Value.BasicConsume(
            queue: queueName,
            autoAck: false,
            consumerTag: applicationName,
            consumer: consumer);
    }

    private string ConvertStreamToString(ReadOnlyMemory<byte> body) => System.Text.Encoding.UTF8.GetString(body.ToArray());

    private void OnMessageNotDelivered(object sender, BasicReturnEventArgs e)
    {
        Console.WriteLine($"Could not deliver message {ConvertStreamToString(e.Body)}");
    }

    public void Produce(string exchangeName, string msg, string routingKey = "")
    {
        _channel.Value.BasicReturn += OnMessageNotDelivered;
        _channel.Value.BasicPublish(
            exchange: exchangeName,
            routingKey: routingKey,
            mandatory: true,
            basicProperties: null,
            body: System.Text.Encoding.UTF8.GetBytes(msg));
    }

    public void Dispose()
    {
        if (_channel.IsValueCreated)
            _channel.Value.Dispose();
        if (_connection.IsValueCreated)
            _connection.Value.Dispose();

    }
}