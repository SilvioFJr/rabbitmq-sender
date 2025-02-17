using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sender.Models;


namespace Sender.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IChannel _channel;
        private readonly string _queueName;
        
        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;

            _queueName = configuration["RabbitMQ:ReferralQueueName"] ?? "hello";


            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQ:HostName"] ?? "localhost",
                UserName = _configuration["RabbitMQ:UserName"] ?? "guest",
                Password = _configuration["RabbitMQ:Password"] ?? "guest",
            };

            _connection = factory.CreateConnectionAsync().Result;
            _channel = _connection.CreateChannelAsync().Result;

            _channel.QueueDeclareAsync(
                queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

        }

        public async Task SendMessage<T>(T data)
        {
            try
            {
                Console.WriteLine($"data: {data}");

                var message = JsonSerializer.Serialize(data);
                var body = Encoding.UTF8.GetBytes(message);

                await _channel.BasicPublishAsync(
                    exchange: string.Empty,
                    routingKey: _queueName,
                    body: body
                );

                Console.WriteLine($" [x] Sent {message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SendMessage] Erro ao enviar mensagem: {ex.Message}");
                throw;
            }
        }       
    }
}

