using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {
        [Key]
        public int MovieId { get; set; }
        [Key]
        public int CastId { get; set; }
        [Key]
        [StringLength(450)]
        public string Character { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        [ForeignKey("CastId")]
        public Cast Cast { get; set; }


    }
}
