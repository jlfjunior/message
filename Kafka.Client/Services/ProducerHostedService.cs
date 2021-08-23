using Confluent.Kafka;
using Kafka.Client.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Client.Services
{
    public class ProducerHostedService : BackgroundService, IHostedService
    {
        private readonly ILogger<ProducerHostedService> _logger;
        private readonly IProducer<Null, string> _producer;

        public ProducerHostedService(ILogger<ProducerHostedService> logger)
        {
            _logger = logger;
            _producer = new ProducerBuilder<Null, string>(
                new ProducerConfig
                {
                    BootstrapServers = "localhost:9092"
                }).Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Working: {nameof(ProducerHostedService)}");

            while (!stoppingToken.IsCancellationRequested)
            {
                var producerResult = await _producer.ProduceAsync(topic: "people", new Message<Null, string> { Value = new Person().ToString() });

                _logger.LogInformation($"Message push Offset: {producerResult.Offset} - {nameof(ProducerHostedService)}");

                Thread.Sleep(30000);
            }

            _producer.Flush(TimeSpan.FromSeconds(10));
        }
    }
}
