using MassTransit;
using RabbitMQ.Client;
using SharedContracts.Events;

namespace Univan.Api.Extensions
{
    public static class MassTransitExtension
    {
        public static void AddMassTransitDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();
                x.UsingRabbitMq((context, busFactoryConfigurator) =>
                {
                    busFactoryConfigurator.Host(configuration.GetConnectionString("RabbitMq"));

                    busFactoryConfigurator.Message<BaseUnivanEvent>(e => e.SetEntityName(BaseUnivanEvent.exchageName));
                    busFactoryConfigurator.Publish<BaseUnivanEvent>(e => { 
                        e.ExchangeType = ExchangeType.Direct; 
                    });

                });
            });
        }
    }
}
