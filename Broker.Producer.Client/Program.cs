using Kafka.Client.Extensions;
using Microsoft.Extensions.Hosting;

namespace Broker.Producer.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddKafkaProducersServices();
                });
    }
}
