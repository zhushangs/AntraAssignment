using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        public EmployeeService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<EmployeeResponseModel> CreateEmployee(EmployeeRequestModel employeeRequestModel)
        {
            var dbEmployee = await _employeesRepository.GetEmployeeByName(employeeRequestModel.Name);
            if (dbEmployee != null)
            {
                throw new Exception("Employee exists, try Login");
            }
            //var salt = CreateSalt();
            //var hashedPassword = CreateHashedPassword(employeeRequestModel.Password, salt);
            var employee = new Employees
            {
                Name = employeeRequestModel.Name,
                Password = employeeRequestModel.Password,
                Designation = employeeRequestModel.Designation,
            };
            var response = await _employeesRepository.AddAsync(employee);
            var createdEmployee = new EmployeeResponseModel
            {
                Id = response.Id,
                Name = response.Name,
                Designation = response.Designation,
            };
            return createdEmployee;
        }

        public async Task DeleteEmployee(int id)
        {
            //var deletedEmployee = await _employeesRepository.ListAsync(e=>e.Id == id);
            //await _employeesRepository.DeleteAsync(deletedEmployee.First());
            var deletedEmployee = await _employeesRepository.GetByIdAsync(id);
            if (deletedEmployee == null)
            {
                throw new Exception("No Such Employee");
            }
            await _employeesRepository.DeleteAsync(deletedEmployee);
        }

        public async Task<List<EmployeeResponseModel>> GetAllEmployees()
        {
            var employees = await _employeesRepository.GetAllEmployees();
            var employeeList = new List<EmployeeResponseModel>();
            foreach (var employee in employees)
            {
                employeeList.Add(new EmployeeResponseModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Designation = employee.Designation
                });
            }
            return employeeList;
        }

        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var employee = await _employeesRepository.GetByIdAsync(id);
            var response = new EmployeeResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Designation = employee.Designation,
            };
            return response;
        }

        public async Task<EmployeeResponseModel> UpdateEmployee(EmployeeUpdateRequestModel employeeUpdateRequestModel, int id)
        {
            var dbEmployee = await _employeesRepository.GetByIdAsync(id);
            if (dbEmployee == null)
            {
                throw new Exception("Employee Not Exist");
            }

            var employee = new Employees
            {
                Id = dbEmployee.Id,
                Name = employeeUpdateRequestModel.Name == null ? dbEmployee.Name : employeeUpdateRequestModel.Name,
                Password = employeeUpdateRequestModel.Password == null ? dbEmployee.Password : employeeUpdateRequestModel.Password,
                Designation = employeeUpdateRequestModel.Designation == null ? dbEmployee.Designation : employeeUpdateRequestModel.Designation,
            };
            var updateEmployee = await _employeesRepository.UpdateAsync(employee);
            var response = new EmployeeResponseModel
            {
                Id = updateEmployee.Id,
                Name = updateEmployee.Name,
                Designation = updateEmployee.Designation,
            };
            return response;
        }

        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public async Task<Employees> GetEmployee(string name)
        {
            return await _employeesRepository.GetEmployeeByName(name);
        }

        public async Task<EmployeeResponseModel> ValidateUser(string name, string password)
        {
            var dbEmployee = await _employeesRepository.GetEmployeeByName(name);
            if (dbEmployee == null)
            {
                return null;
            }
            if(password == dbEmployee.Password)
            {
                var response = new EmployeeResponseModel
                {
                    Id = dbEmployee.Id,
                    Name = dbEmployee.Name,
                    Designation = dbEmployee.Designation,
                };
                return response;
            }
            return null;
        }
    }
}
