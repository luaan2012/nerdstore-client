using MediatR;

namespace NS.Clientes.API.Application.Events
{
    public class ClienteEventHandler : INotificationHandler<ClientRegistradoEvent>
    {
        public Task Handle(ClientRegistradoEvent notification, CancellationToken cancellationToken)
        {
            // Enviar evento de confirmação
            return Task.CompletedTask;
        }
    }
}