using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class MovieUpdateRequestModel
    {
        public int Id { get; }
        public string Title { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
    }
}
