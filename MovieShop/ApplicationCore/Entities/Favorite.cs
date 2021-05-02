using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
