using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository : EfRepository<Clients>, IClientsRepository
    {
        public ClientRepository(ClientInformationDBContext dBContext) : base(dBContext)
        {

        }

        public async Task<IEnumerable<Clients>> GetAllClients()
        {
            var clients = await _dbContext.Clients.OrderBy(e => e.Id).ToListAsync();
            return clients;
        }

        public override async Task<Clients> GetByIdAsync(int id)
        {
            var client = await _dbContext.Clients.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return client;
        }
    }
}
