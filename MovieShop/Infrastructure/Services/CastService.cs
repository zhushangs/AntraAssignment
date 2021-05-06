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
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<List<CastResponseModel>> GetFirst10Cast()
        {
            var casts = await _castRepository.GetFirst10Casts();
            var first10Casts = new List<CastResponseModel>();
            foreach (var cast in casts)
            {
                first10Casts.Add(new CastResponseModel
                {
                    Id = cast.Id,
                    Name = cast.Name,
                    Gender = cast.Gender,
                    TmdbUrl = cast.TmdbUrl,
                    ProfilePath = cast.ProfilePath
                });
            }
            return first10Casts;
        }
        public async Task<CastResponseModel> GetCastById(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            var theCast = new CastResponseModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath
            };
            return theCast;
        }
    }
}
