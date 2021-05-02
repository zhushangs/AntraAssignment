using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Review
    {
        [Key]
        public int MovieId { get; set; }
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal Rating { get; set; }
        public string? ReviewText { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
