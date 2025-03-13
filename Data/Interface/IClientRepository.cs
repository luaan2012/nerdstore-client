using NS.Cliente.API.Models;
using NS.Core.Data;

namespace NS.Clientes.API.Data.Interface
{
    public interface IClientRepository : IRepository<Client>
    {
        void Add(Client client);

        Task<IEnumerable<Client>> GiveAll();
        Task<Client> GiveByCpf(string cpf);

        void AddAddress(Address address);
        void EditAddress(Address address);
        Task<Address> GiveAddressById(Guid id);
    }
}