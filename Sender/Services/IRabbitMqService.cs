using Sender.Models;

namespace Sender.Services
{
    public interface IRabbitMqService
    {
        Task SendMessage(Order order);
    }
}
