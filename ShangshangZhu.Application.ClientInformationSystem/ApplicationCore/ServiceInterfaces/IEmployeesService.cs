using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeesService
    {
        Task<List<EmployeeResponseModel>> GetAllEmployees();
        Task<EmployeeResponseModel> CreateEmployee(EmployeeRequestModel employeeRequestModel);
        Task<EmployeeResponseModel> GetEmployeeById(int id);
        Task<EmployeeResponseModel> UpdateEmployee(EmployeeUpdateRequestModel employeeUpdateRequestModel);
        Task DeleteEmployee(int id);
        Task<Employees> GetEmployee(string name);
        Task<EmployeeResponseModel> ValidateUser(string name, string password);
    }
}
