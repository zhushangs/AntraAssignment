﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class FavoriteRequestModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}
