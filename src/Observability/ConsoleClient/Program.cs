namespace ConsoleClient;

using Core.MessageQueue;

internal class Program
{
    static void Main(string[] args)
    {
        using var rmq = new RabbitMqClient("localhost");

        rmq.Consume("TestApplication", "queue1", (arg) =>
        {
            Console.WriteLine(arg);
        });

        Console.WriteLine("Press enter to exit");
        Console.ReadLine();
    }
}
