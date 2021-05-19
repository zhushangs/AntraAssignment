using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class InteractionRequestModel
    {
        public int? ClientId { get; set; }
        public int? EmpId { get; set; }
        public char? type { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }
    }
}
