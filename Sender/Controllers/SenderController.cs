using Microsoft.AspNetCore.Mvc;
using Sender.Models;
using Sender.ViewModels;
using Sender.Services;


namespace Sender.Controllers
{

    [ApiController]
    [Route("api/sender")]
    public class SenderController : ControllerBase
    {
        private readonly IRabbitMqService _rabbitMqService;

        public SenderController(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        [HttpPost("emit-order")]
        public async Task<IActionResult> EmitOrder([FromBody] OrderViewModel order)
        {
            if (
                order == null || 
                string.IsNullOrEmpty(order.Name) || 
                order.Value <= 0 || 
                order.Quantity <= 0
            )
            {
                return BadRequest("Dados do produto inválidos.");
            }

            var data = new Order
            {
                Id = Guid.NewGuid(),
                Name = order.Name,
                Value = order.Value,
                Quantity = order.Quantity,
            };

            await _rabbitMqService.SendMessage(data);

            return Ok("Order emitted");
        }
    }
}

