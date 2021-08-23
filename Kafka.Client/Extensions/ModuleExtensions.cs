using Kafka.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kafka.Client.Extensions
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddKafkaServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentException($"{nameof(IServiceCollection)} is null");

            services.AddHostedService<ProducerHostedService>();
            services.AddHostedService<ConsumerHostedService>();

            return services;
        }
    }
}
