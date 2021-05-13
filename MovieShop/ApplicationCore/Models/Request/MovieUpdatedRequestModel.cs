using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class MovieUpdatedRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
    }
}
