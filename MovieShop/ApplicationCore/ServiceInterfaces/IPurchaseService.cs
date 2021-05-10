﻿using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<MovieCardResponseModel>> GetAllPurchasedMovie(int id);
    }
}
