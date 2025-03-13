using Microsoft.EntityFrameworkCore;
using NS.Cliente.API.Models;
using NS.Clientes.API.Data.Interface;
using NS.Core.Data;

namespace NS.Clientes.API.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientsContext _context;

        public ClientRepository(ClientsContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Client>> GiveAll()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

        public Task<Client> GiveByCpf(string cpf)
        {
            return _context.Clients.FirstOrDefaultAsync(c => c.Cpf.Number == cpf);
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
        }

        public async Task<Address> GiveAddressById(Guid id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(e => e.ClientId == id);
        }

        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
        }

        public void EditAddress(Address editAddress)
        {
            _context.Addresses.Update(editAddress);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}