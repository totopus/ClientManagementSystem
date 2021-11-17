using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace TaskManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : ControllerBase
    {
        private readonly IInteractionService _interactionService;
        public InteractionController(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        [HttpGet]
        [Route("ListInteractions")]
        public async Task<IActionResult> GetInteractions()
        {
            var interactions = await _interactionService.GetInteractions();

            if (!interactions.Any())
            {
                return NotFound("No Interactions Found");
            }

            return Ok(interactions);
        }

        //http://localhost/api/interaction/1
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetInteraction(int id)
        {
            var interaction = await _interactionService.GetInteractionById(id);
            if (interaction == null)
            {
                return NotFound($"No Interaction Found For {id}");
            }
            return Ok(interaction);
        }

        //http://localhost/api/addinteraction
        [HttpPost]
        [Route("addinteraction")]
        public async Task<IActionResult> AddInteraction([FromBody] InteractionRequestModel model)
        {
            var addInteraction = await _interactionService.AddInteraction(model);

            return Ok(addInteraction);
        }

        [HttpDelete]
        [Route("deleteinteraction/{id:int}")]
        public async Task<IActionResult> DeleteInteraction(int id)
        {
            await _interactionService.DeleteInteraction(id);
            return Ok();
        }

        [HttpPut]
        [Route("updateinteraction/{id:int}")]
        public async Task<IActionResult> UpdateInteraction(int id, InteractionRequestModel model)
        {
            var updatedInteraction = await _interactionService.UpdateInteraction(id, model);
            return Ok(updatedInteraction);
        }
    }
}

