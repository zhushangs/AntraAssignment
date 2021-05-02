using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCrew
    {
        [Key]
        public int MovieId { get; set; }
        [Key]
        public int CrewId { get; set; }
        [Key]
        [StringLength(128)]
        public string Department { get; set; }
        [Key]
        [StringLength(128)]
        public string Job { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        [ForeignKey("CrewId")]
        public Crew Crew { get; set; }
    }
}
