using DotNetEnv;
using Sender.Services;

namespace Sender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Env.Load("./../.env");

            var builder = WebApplication.CreateBuilder(args);

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "NOT_KNOWN";
            var HTTP_PORT = Environment.GetEnvironmentVariable("HTTP_PORT") ?? "9000";
            var HTTPS_PORT = Environment.GetEnvironmentVariable("HTTPS_PORT") ?? "9001";

            builder.Environment.EnvironmentName = environment;

            builder.WebHost.UseUrls(
                $"http://localhost:{HTTP_PORT}",
                $"https://localhost:{HTTPS_PORT}"
            );

            Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);

            Console.WriteLine($"QueueName: {builder.Configuration["RabbitMQ:QueueName"]}");

            builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Receiver API v1");
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.MapGet("/", () => "Healthy");

            app.MapControllers();

            app.Run();
        }
    }
}
