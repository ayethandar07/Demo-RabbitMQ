using Microsoft.Extensions.Options;
using RabbitMQDemo.Models;
using RabbitMQDemo.RabbitMQ;
using RabbitMQDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bind RabbitMQSettings to configuration
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));

// Register RabbitMQService as a singleton and configure it to use IOptions<RabbitMQSettings>
builder.Services.AddSingleton<IRabbitMQService>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<RabbitMQSettings>>().Value;
    return new RabbitMQService(settings);
});

// Register MessageProducer and MessageConsumer as transient
builder.Services.AddTransient<MessageProducer>();
builder.Services.AddTransient<MessageConsumer>();

// Register a background service to start the consumer
builder.Services.AddHostedService<ConsumerBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
