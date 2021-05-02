using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        [StringLength(450)]
        public string? TrailerUrl { get; set; }
        [StringLength(450)]
        public string? Name { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}
