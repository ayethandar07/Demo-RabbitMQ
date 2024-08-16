using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQDemo.Services;
using System.Text;

namespace RabbitMQDemo.RabbitMQ;

public class MessageConsumer
{
    private readonly IRabbitMQService _rabbitMQService;

    public MessageConsumer(IRabbitMQService rabbitMQService)
    {
        _rabbitMQService = rabbitMQService;
    }

    public void StartConsumer(string queueName)
    {
        var channel = _rabbitMQService.CreateChannel();
        channel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received: {0}", message);
        };

        // Use BasicConsume to start consuming messages from the queue
        channel.BasicConsume(queue: queueName,
                             autoAck: true, // Automatically acknowledge receipt of messages
                             consumer: consumer);

        Console.WriteLine("Consumer started. Press [enter] to exit.");
        Console.ReadLine(); // Keep the application running to listen for messages
    }
}
