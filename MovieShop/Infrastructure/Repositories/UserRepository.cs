using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
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
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext): base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            //var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<IEnumerable<Movie>> GetUserFavoriteMoviesAsync(int id)
        {
            var movies = await _dbContext.Favorites.Where(f => f.UserId == id).Include(f => f.Movie)
                .Select(f => new Movie { 
                    Id = f.Movie.Id,
                    Title = f.Movie.Title,
                    PosterUrl = f.Movie.PosterUrl
                }).ToListAsync();
            return movies;
        }

        public async Task<User> GetUserProfileAsync(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<Review>> GetUserReviewsAsync(int id)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.UserId == id).Include(r => r.Movie).Include(r => r.User).ToListAsync();
            return reviews;
        }
    }
}
