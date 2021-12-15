using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {

        Task<Client> SaveClientAsync(Client client);
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetClientbyName(string name);

        Task<Client> GetById(int id);

        Task DeleteClient(int id);

        Task UpdateClient(Client client);

    }
}
