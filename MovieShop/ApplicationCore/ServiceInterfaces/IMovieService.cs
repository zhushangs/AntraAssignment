using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieCardResponseModel>> GetAllMovies();
        Task<List<MovieCardResponseModel>> GetTop30RevenueMovie();
        Task<IEnumerable<MovieCardResponseModel>> GetTop30RatedMovie();
        Task<MovieCardResponseModel> GetMovieCardById(int id);
        Task<List<MovieCardResponseModel>> GetMoviesByGenre(int id);
        Task<IEnumerable<MovieReviewResponseModel>> GetMovieReviews(int id);
        Task<MovieCardResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequestModel);
        Task<MovieCardResponseModel> UpdateMovie(MovieUpdateRequestModel movieUpdateRequestModel);
    }
}