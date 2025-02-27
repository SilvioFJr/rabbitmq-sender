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

        [HttpPost("send-first-contact-message")]
        public async Task<IActionResult> sendFirstContactMessage([FromBody] sendFirstContactWhatsappTemplateViewModel message)
        {
            if (
                message == null ||
                string.IsNullOrEmpty(message.PhoneNumberTo) ||
                string.IsNullOrEmpty(message.Language) ||
                string.IsNullOrEmpty(message.TemplateName)
            )
            {
                return BadRequest("Dados do produto inválidos.");
            }

            var data = new TemplateMessage
            {
                TemplateName = message.TemplateName,
                PhoneNumberTo = message.PhoneNumberTo,
                Language = message.Language,
                TemplateData = message.TemplateData,
            };

            await _rabbitMqService.SendMessage(data);

            return Ok("Message sent");
        }

        [HttpPost("send-register-message")]
        public async Task<IActionResult> sendRegisterMessage([FromBody] sendRegisterViewModel message)
        {

            var data = new RegisterMessage
            {
                UserId = message.UserId,
                FirstName = message.FirstName,
                LastName = message.LastName,
                Gender = message.Gender,
                Phone = message.Phone,
                Email = message.Email,
                CustomAttributes = message.CustomAttributes
            };

            await _rabbitMqService.SendMessage(data);

            return Ok("Message sent");
        }
    }
}

