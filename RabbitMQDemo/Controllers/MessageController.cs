using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQDemo.RabbitMQ;

namespace RabbitMQDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageProducer _messageProducer;

        public MessageController(MessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        [HttpPost("send")]
        public IActionResult SendMessage([FromQuery] string queueName, [FromBody] string message)
        {
            _messageProducer.SendMessage(queueName, message);
            return Ok("Message sent.");
        }
    }
}
