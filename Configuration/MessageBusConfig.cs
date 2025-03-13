using NS.Clients.API.Services;
using NS.Core.Utils;
using NS.MessageBus;


namespace NS.Clients.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegisterClientIntegrationHandler>();
        }
    }
}