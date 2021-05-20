using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;
        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientsService.GetAllClients();
            if (clients.Any())
            {
                return Ok(clients);
            }
            return NotFound("No Client Found");
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetClient")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _clientsService.GetClientById(id);
            return Ok(client);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateClient(ClientRequestModel clientRequestModel)
        {
            var createdClient = await _clientsService.CreateClient(clientRequestModel);
            return CreatedAtRoute("GetClient", new { id = createdClient.Id }, createdClient);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateClient(ClientUpdateRequestModel clientUpdateRequestModel, int id)
        {
           
            var updatedClient = await _clientsService.UpdateClient(clientUpdateRequestModel, id);
            return CreatedAtRoute("GetClient", new { id = updatedClient.Id }, updatedClient);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientsService.DeleteClient(id);
            return Ok();
        }

    }
}
