using RabbitMQ.Client;
using RabbitMQDemo.Services;
using System.Text;

namespace RabbitMQDemo.RabbitMQ;

public class MessageProducer
{
    private readonly IRabbitMQService _rabbitMQService;

    public MessageProducer(IRabbitMQService rabbitMQService)
    {
        _rabbitMQService = rabbitMQService;
    }

    public void SendMessage(string queueName, string message)
    {
        using (var channel = _rabbitMQService.CreateChannel())
        {
            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            // Create a new BasicProperties object
            var basicProperties = channel.CreateBasicProperties();

            // Set properties if needed (optional)
            basicProperties.Persistent = false;

            // BasicPublish requires mandatory and basicProperties parameters
            channel.BasicPublish(exchange: "",
                                 routingKey: queueName,
                                 mandatory: false, // Indicates if the message must be routed
                                 basicProperties: basicProperties,
                                 body: body);
        }
    }
}
