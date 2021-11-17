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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("ListClients")]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _clientService.GetClients();

            if (!clients.Any())
            {
                return NotFound("No Clients Found");
            }

            return Ok(clients);
        }

        //http://localhost/api/client/1
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound($"No Client Found For {id}");
            }
            return Ok(client);
        }

        //http://localhost/api/addclient
        [HttpPost]
        [Route("addclient")]
        public async Task<IActionResult> AddClient([FromBody] ClientRequestModel model)
        {
            var addClient = await _clientService.AddClient(model);

            return Ok(addClient);
        }

        [HttpDelete]
        [Route("deleteclient/{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClient(id);
            return Ok();
        }

        [HttpPut]
        [Route("updateclient/{id:int}")]
        public async Task<IActionResult> UpdateClient(int id, ClientRequestModel model)
        {
            var updatedClient = await _clientService.UpdateClient(id, model);
            return Ok(updatedClient);
        }
    }
}

