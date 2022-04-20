using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeContrato.API.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services;
using TeContrato.API.Resources;

namespace TeContrato.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class ClientsController : ControllerBase
        {
            private readonly IClientService _clientService;
            private readonly IMapper _mapper;

            public ClientsController(IClientService clientService, IMapper mapper)
            {
                _clientService = clientService;
                _mapper = mapper;
            }

            [SwaggerResponse(200, "List of Clients", typeof(IEnumerable<ClientResource>))]
            [ProducesResponseType(typeof(IEnumerable<ClientResource>), 200)]
            [HttpGet]
            [SwaggerOperation(Summary = "List all clients")]
            public async Task<IEnumerable<ClientResource>> GetAllAsync()
            {
                var clients = await _clientService.ListAsync();
                var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
                return resources;
            }
            
            [HttpGet("{Cclient}")]
            [SwaggerOperation(Summary = "Get a client by Id")]
            [ProducesResponseType(typeof(ClientResource), 200)]
            [ProducesResponseType(typeof(BadRequestResult), 404)]
            public async Task<IActionResult> GetAsync(int id)
            {
                var result = await _clientService.GetByIdAsync(id);

                if (!result.Success)
                    return BadRequest(result.Message);

                var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
                return Ok(clientResource);
            }

            [HttpPost]
            [SwaggerOperation(Summary = "Create a client")]
            [ProducesResponseType(typeof(ClientResource), 200)]
            [ProducesResponseType(typeof(BadRequestResult), 404)]
            public async Task<IActionResult> PostAsync(int cityId, [FromBody] SaveClientResource resource)
            {
                
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }

                var platform = _mapper.Map<SaveClientResource, Client>(resource);
                var result = await _clientService.SaveAsync(cityId, platform);

                if (!result.Success)
                    return BadRequest(result.Message);

                var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
                return Ok(clientResource);
            }
            
            [HttpPut("{Cclient}")]
            [SwaggerOperation(Summary = "Update a client by Id")]
            public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClientResource resource)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var category = _mapper.Map<SaveClientResource, Client>(resource);
                var result = await _clientService.UpdateAsync(id, category);

                if (!result.Success)
                    return BadRequest(result.Message);

                var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);

                return Ok(clientResource);
            }
            
            [HttpDelete("{Cclient}")]
            [SwaggerOperation(Summary = "Delete a client by Id")]
            public async Task<IActionResult> DeleteAsync(int id)
            {
                var result = await _clientService.DeleteAsync(id);

                if (!result.Success)
                    return BadRequest(result.Message);

                var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);

                return Ok(clientResource);

            }
        }
    }

