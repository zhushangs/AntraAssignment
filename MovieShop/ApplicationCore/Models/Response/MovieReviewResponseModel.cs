﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Response
{
    public class MovieReviewResponseModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
