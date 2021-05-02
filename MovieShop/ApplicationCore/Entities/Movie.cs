using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Title { get; set; }
        public string? Overview { get; set; }
        [StringLength(512)]
        public string? Tagline { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Budget { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Revenue { get; set; }

        [StringLength(2084)]
        public string? ImdbUrl { get; set; }

        [StringLength(2084)]
        public string? TmdbUrl { get; set; }

        [StringLength(2084)]
        public string? PosterUrl { get; set; }

        [StringLength(2084)]
        public string? BackdropUrl { get; set; }

        [StringLength(64)]
        public string? OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
    }
}
