using RabbitMQ.Client;
using RabbitMQDemo.Models;

namespace RabbitMQDemo.Services;

public class RabbitMQService : IRabbitMQService
{
    private readonly RabbitMQSettings _settings;

    public RabbitMQService(RabbitMQSettings settings)
    {
        _settings = settings;
    }

    public IModel CreateChannel()
    {
        var factory = new ConnectionFactory
        {
            HostName = _settings.HostName,
            UserName = _settings.UserName,
            Password = _settings.Password,
            VirtualHost = _settings.VirtualHost
        };

        var connection = factory.CreateConnection();
        return connection.CreateModel();
    }
}