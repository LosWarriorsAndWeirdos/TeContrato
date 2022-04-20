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
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;

        public StatusController(IStatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StatusResource>> GetAllAsync()
        {
            var employees = await _statusService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Status>, IEnumerable<StatusResource>>(employees);
            return resources;
        }
        
        [HttpGet("{Cemployee}")]
        [SwaggerOperation(Summary = "Get a status by Id")]
        [ProducesResponseType(typeof(StatusResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _statusService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Status, StatusResource>(result.Resource);
            return Ok(employeeResource);
        }
        
        [HttpPut("{Cemployee}")]
        [SwaggerOperation(Summary = "Update a status")]
        [ProducesResponseType(typeof(StatusResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int Id, [FromBody] SaveStatusResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveStatusResource, Status>(resource);
            var result = await _statusService.UpdateAsync(Id, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Status, StatusResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a status")]
        [ProducesResponseType(typeof(StatusResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveStatusResource resource)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var employee = _mapper.Map<SaveStatusResource, Status>(resource);
            var result = await _statusService.SaveAsync(employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Status, StatusResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpDelete("{Cemployee}")]
        [SwaggerOperation(Summary = "Delete a status by Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _statusService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Status, StatusResource>(result.Resource);

            return Ok(employeeResource);

        }
    }
}