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
    public class InteractionsController : ControllerBase
    {
        private readonly IInteractionsService _interactionsService;
        public InteractionsController(IInteractionsService interactionsService)
        {
            _interactionsService = interactionsService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllInteractions()
        {
            var interactions = await _interactionsService.GetAllInteractions();
            if (interactions.Any())
            {
                return Ok(interactions);
            }
            return NotFound("No Interactions Found");
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetInteraction")]
        public async Task<IActionResult> GetInteractionById(int id)
        {
            var interaction = await _interactionsService.GetInteractionById(id);
            return Ok(interaction);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateInteraction(InteractionRequestModel interactionRequestModel)
        {
            var createdInteraction = await _interactionsService.CreateInteraction(interactionRequestModel);
            return CreatedAtRoute("GetInteraction", new { id = createdInteraction.Id }, createdInteraction);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdateInteraction(InteractionUpdateRequestModel interactionUpdateRequestModel, int id)
        {
            var updatedInteraction = await _interactionsService.UpdateInteraction(interactionUpdateRequestModel, id);
            return CreatedAtRoute("GetInteraction", new { id = updatedInteraction.Id }, updatedInteraction);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteInteraction(int id)
        {
            await _interactionsService.DeleteInteraction(id);
            return Ok();
        }
    }
}
