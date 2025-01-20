using Sender.Models;

namespace Sender.Services
{
    public interface IRabbitMqService
    {
        Task SendMessage<T>(T data);
    }
}
