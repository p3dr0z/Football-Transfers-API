namespace FootballTransfersAPI.Data.Services.Messaging
{
    using System.Text;
    using System.Text.Json;
    using FootballTransfersAPI.Data.Services.Interfaces.Messaging;
    using RabbitMQ.Client;

    public class MessageProducerService : IMessageProducerService
    {
        public void ProduceMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare("test", durable: true, exclusive: false);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish(string.Empty, "test", body: body);
        }
    }
}
