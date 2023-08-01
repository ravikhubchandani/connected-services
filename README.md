# connected-services
Web api with web client and console client. Api connects to Postgre and Rabbit MQ. Web client connects to Api service and console connects to Rabbit MQ. Postgre DB and Rabbit on Docker

After cloning:
* Run provided `docker-compose.yml` in CMD with command `docker compose up`
* Initialize database running the provided SQL `database.sql`, for example connecting with Azure Data Studio
* Run provided `message_queue.bat` in Docker Desktop terminal for RabbitMQ

Test it:
* In Visual Studio set Catalogue, Client and ConsoleClient as startup projects
* Open web client `https://localhost:7297/swagger/index.html`
* Endpoint `https://localhost:7297/Bridge/get-animals` will request a list of animals from database
* At the same time, the server will push data to Rabbit MQ and the console app will consume and display it
