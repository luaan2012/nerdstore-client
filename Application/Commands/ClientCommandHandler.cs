using FluentValidation.Results;
using MediatR;
using NS.Clientes.API.Application.Events;
using NS.Core.Messages;
using NS.Clients.API.Application.Commands;
using NS.Clientes.API.Data.Interface;
using NS.Cliente.API.Models;
using NS.APICore.User;

namespace NS.Clientes.API.Application.Commands
{
    public class ClientCommandHandler : CommandHandler,
        IRequestHandler<RegisterClientCommand, ValidationResult>,
        IRequestHandler<AddAddressCommand, ValidationResult>,
        IRequestHandler<EditAddressCommand,ValidationResult>
    {
        private readonly IClientRepository _clienteRepository;
        private readonly IAspNetUser _user;

        public ClientCommandHandler(IClientRepository clienteRepository, IAspNetUser user)
        {
            _clienteRepository = clienteRepository;
            _user = user;
        }

        public async Task<ValidationResult> Handle(RegisterClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var client = new Client(message.Id, message.Name, message.Email, message.Cpf);

            var existClient = await _clienteRepository.GiveByCpf(client.Cpf.Number);

            if (existClient != null)
            {
                AddError("Este CPF já está em uso.");
                return ValidationResult;
            }

            _clienteRepository.Add(client);

            client.AddEvent(new ClientRegistradoEvent(message.Id, message.Name, message.Email, message.Cpf));

            return await PersistData(_clienteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AddAddressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var address = new Address(message.PublicPlace, message.Number, message.Complement, message.Neighborhood, message.Cep, message.City, message.State, message.ClientId);
            _clienteRepository.AddAddress(address);

            return await PersistData(_clienteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditAddressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;          

            var commandEdit = new Address(message.PublicPlace, message.Number, message.Complement, message.Neighborhood, message.Cep, message.City, message.State, message.ClientId);

            commandEdit.Id = message.Id;

            _clienteRepository.EditAddress(commandEdit);

            return await PersistData(_clienteRepository.UnitOfWork);
        }
    }
}