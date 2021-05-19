using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IEmployeesRepository : IAsyncRepository<Employees>
    {
        Task<IEnumerable<Employees>> GetAllEmployees();
        Task<Employees> GetEmployeeByName(string name);
    }
}
