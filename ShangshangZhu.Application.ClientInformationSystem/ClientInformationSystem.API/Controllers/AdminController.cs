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
    public class AdminController : ControllerBase
    {
        private readonly IClientsService _clientsService;
        private readonly IInteractionsService _interactionsService;
        private readonly IEmployeesService _employeesService;
        public AdminController(IClientsService clientsService, IInteractionsService interactionsService, IEmployeesService employeesService) 
        {
            _clientsService = clientsService;
            _interactionsService = interactionsService;
            _employeesService = employeesService;
        }

        [HttpPost]
        [Route("client")]
        public async Task<IActionResult> CreateClient(ClientRequestModel clientRequestModel)
        {
            var createdClient = await _clientsService.CreateClient(clientRequestModel);
            return CreatedAtRoute("GetClient", new { id = createdClient.Id }, createdClient);
        }

        [HttpDelete]
        [Route("client/{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientsService.DeleteClient(id);
            return Ok();
        }

        [HttpDelete]
        [Route("employee/{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeesService.DeleteEmployee(id);
            return Ok();
        }
    }
}
