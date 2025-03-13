using Microsoft.AspNetCore.Mvc;
using NS.ApiCore.Controllers;
using NS.APICore.User;
using NS.Clientes.API.Application.Commands;
using NS.Clientes.API.Data.Interface;
using NS.Core.Mediator;

namespace NS.Clientes.API.Controllers
{
    public class ClientController : MainController
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public ClientController(IClientRepository clientRepository, IMediatorHandler mediator, IAspNetUser user)
        {
            _clientRepository = clientRepository;
            _mediator = mediator;
            _user = user;
        }

        [HttpGet("client/address")]
        public async Task<IActionResult> GiveAddress()
        {
            var address = await _clientRepository.GiveAddressById(_user.ObterUserId());

            return address == null ? NotFound() : CustomResponse(address);
        }

        [HttpPost]
        [Route("client/address")]
        public async Task<IActionResult> AddAddress(AddAddressCommand address)
        {
            address.ClientId = _user.ObterUserId();
            return CustomResponse(await _mediator.SendCommand(address));
        }

        [HttpPost]
        [Route("client/edit-address")]
        public async Task<IActionResult> EditAddress(EditAddressCommand address)
        {
            address.ClientId = _user.ObterUserId();
            return CustomResponse(await _mediator.SendCommand(address));
        }
    }
}