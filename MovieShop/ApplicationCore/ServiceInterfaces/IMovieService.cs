using ApplicationCore.Entities;
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
    }
}
