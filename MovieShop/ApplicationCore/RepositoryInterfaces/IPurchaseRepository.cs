﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IPurchaseRepository : IAsyncRepository<Purchase>
    {
        Task<IEnumerable<Movie>> GetPurchasedMovieByUser(int userId);
    }
}
