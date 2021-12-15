using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.BaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly SiemensContext _context;

        public ClientRepository(SiemensContext context)
        {
            _context = context;
        }

        public async Task<Client> SaveClientAsync(Client client)
        {
            await _context.Client.AddAsync(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Client.Where(x => x.ExclusionDate == null).ToListAsync();
        }

        public async Task<Client> GetClientbyName(string name)
        {
            return await _context.Client.Where(x => x.Name == name && x.ExclusionDate == null).FirstOrDefaultAsync();

        }

        public async Task<Client> GetById(int id)
        {
            return await _context.Client.Where(x => x.Id == id && x.ExclusionDate == null).FirstOrDefaultAsync();

        }

        public async Task DeleteClient(int id)
        {
            var client = await GetById(id);

            if (client != null)
            {
                client.ExclusionDate = DateTime.Now;
                await UpdateClient(client);
            }
        }

        public async Task UpdateClient(Client client)
        {
            client.UpdationDate = DateTime.Now;
            _context.Client.Update(client);
            await _context.SaveChangesAsync();
        }

        // Excluir do banco poderia ser assim.
        //public async Task DeleteClient(int id)
        //{
        //    var client = await GetById(id);

        //    if(client != null)
        //    {
        //        _context.Client.Remove(client);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
