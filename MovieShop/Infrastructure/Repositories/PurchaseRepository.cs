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
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Movie>> GetPurchasedMovieByUser(int userId)
        {
            var movies = await _dbContext.Purchases.Where(p => p.UserId == userId).Include(p => p.Movie).Select(p => p.Movie).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            var purchse =  await _dbContext.Purchases.Include(p=>p.Movie).ToListAsync();
            return purchse;
        }
    }
}
