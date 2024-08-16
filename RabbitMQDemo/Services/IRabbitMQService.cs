using RabbitMQ.Client;

namespace RabbitMQDemo.Services;

public interface IRabbitMQService
{
    IModel CreateChannel();
}
