namespace RabbitMQDemo.Services;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQDemo.RabbitMQ;

public class ConsumerBackgroundService : BackgroundService
{
    private readonly ILogger<ConsumerBackgroundService> _logger;
    private readonly MessageConsumer _messageConsumer;
    private readonly string _queueName = "your_queue_name"; // Replace with your queue name

    public ConsumerBackgroundService(
        ILogger<ConsumerBackgroundService> logger,
        MessageConsumer messageConsumer)
    {
        _logger = logger;
        _messageConsumer = messageConsumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Starting RabbitMQ consumer...");

        _messageConsumer.StartConsumer(_queueName);

        // Keep the service running
        await Task.CompletedTask;
    }
}

