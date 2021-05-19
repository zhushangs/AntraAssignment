using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class EmployeeLoginRequestModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
