using Kafka.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kafka.Client.Extensions
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddKafkaProducersServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentException($"{nameof(IServiceCollection)} is null");

            services.AddHostedService<ProducerHostedService>();

            return services;
        }

        public static IServiceCollection AddKafkaConsumersServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentException($"{nameof(IServiceCollection)} is null");

            services.AddHostedService<ConsumerHostedService>();

            return services;
        }
    }
}
