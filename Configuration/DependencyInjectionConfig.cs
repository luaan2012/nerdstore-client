using FluentValidation.Results;
using MediatR;
using NS.APICore.User;
using NS.Clientes.API.Application.Commands;
using NS.Clientes.API.Data;
using NS.Clientes.API.Data.Interface;
using NS.Clientes.API.Data.Repository;
using NS.Clients.API.Application.Commands;
using NS.Core.Mediator;
using NS.Clientes.API.Application.Events;

namespace NS.Clients.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<RegisterClientCommand, ValidationResult>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<AddAddressCommand, ValidationResult>, ClientCommandHandler>();
            services.AddScoped<IRequestHandler<EditAddressCommand, ValidationResult>, ClientCommandHandler>();

            services.AddScoped<INotificationHandler<ClientRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ClientsContext>();
        }
    }
}