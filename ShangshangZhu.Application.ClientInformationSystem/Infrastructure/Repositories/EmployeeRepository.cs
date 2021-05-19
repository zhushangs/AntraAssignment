using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : EfRepository<Employees>, IEmployeesRepository
    {
        public EmployeeRepository(ClientInformationDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<IEnumerable<Employees>> GetAllEmployees()
        {
            var employees = await _dbContext.Employees.OrderBy(e => e.Id).ToListAsync();
            return employees;
        }

        public override async Task<Employees> GetByIdAsync(int id)
        {
            var employee = await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }

        public async Task<Employees> GetEmployeeByName(string name)
        {
            var employees = await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(u => u.Name == name);
            return employees;
        }
    }
}
