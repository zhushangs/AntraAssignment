using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInformationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IClientsService _clientsService;
        private readonly IInteractionsService _interactionsService;
        public EmployeesController(IEmployeesService employeesService, IClientsService clientsService, IInteractionsService interactionsService)
        {
            _employeesService = employeesService;
            _clientsService = clientsService;
            _interactionsService = interactionsService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeesService.GetAllEmployees();
            if (employees.Any())
            {
                return Ok(employees);
            }
            return NotFound("No Employee Found");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeesService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdateRequestModel employeeUpdateRequestModel, int id)
        {
            var updatedEmployee = await _employeesService.UpdateEmployee(employeeUpdateRequestModel, id);
            return CreatedAtRoute("GetEmployee", new { id = updatedEmployee.Id }, updatedEmployee);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeesService.DeleteEmployee(id);
            return Ok();
        }

        //[HttpPost]
        //[Route("client")]
        //public async Task<IActionResult> CreateClient(ClientRequestModel clientRequestModel)
        //{
        //    var createdClient = await _clientsService.CreateClient(clientRequestModel);
        //    return CreatedAtRoute("GetClient", new { id = createdClient.Id }, createdClient);
        //}

        //[HttpDelete]
        //[Route("client/{id:int}")]
        //public async Task<IActionResult> DeleteClient(int id)
        //{
        //    await _clientsService.DeleteClient(id);
        //    return Ok();
        //}


        //[HttpPost]
        //[Route("add")]
        //public async Task<IActionResult> CreateEmployee(EmployeeRequestModel employeeRequestModel)
        //{
        //    var createdEmployee = await _employeesService.CreateEmployee(employeeRequestModel);
        //    return CreatedAtRoute("GetEmployee", new { id = createdEmployee.Id }, createdEmployee);
        //}
    }
}
