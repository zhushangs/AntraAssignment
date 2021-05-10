using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public async Task<IEnumerable<MovieCardResponseModel>> GetAllPurchasedMovie(int userId)
        {
            var movies = await _purchaseRepository.GetPurchasedMovieByUser(userId);
            var purchaesdMovies = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                purchaesdMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return purchaesdMovies;

        }
    }
}
