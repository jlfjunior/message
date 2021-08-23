using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Client.Services
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly ILogger<ConsumerHostedService> _logger;
        private readonly IConsumer<Null, string> _consumer;

        public ConsumerHostedService(ILogger<ConsumerHostedService> logger)
        {
            _logger = logger;

            var config = new ConsumerConfig
            {
                GroupId = "Consumer",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<Null, string>(config: config).Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Working: {nameof(ConsumerHostedService)}");

            while (!stoppingToken.IsCancellationRequested)
            {
                _consumer.Subscribe(topic: "people");

                var consumeResult = _consumer.Consume(stoppingToken);

                _logger.LogInformation($"Message read Offset: {consumeResult.Offset} - {nameof(ConsumerHostedService)}");
            }

            _consumer.Close();
        }
    }
}
