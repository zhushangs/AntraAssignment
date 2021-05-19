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
    public class InteractionRepository : EfRepository<Interactions>, IInteractionsRepository
    {
        public InteractionRepository(ClientInformationDBContext dBContext) : base(dBContext)
        {

        }

        public async Task<IEnumerable<Interactions>> GetAllInteractions()
        {
            var interactions = await _dbContext.Interactions.OrderBy(i => i.Id).ToListAsync();
            return interactions;
        }

        public override async Task<Interactions> GetByIdAsync(int id)
        {
            var interacction = await _dbContext.Interactions.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            return interacction;
        }
    }
}
