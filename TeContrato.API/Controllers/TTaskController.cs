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
    public class TTaskController : ControllerBase
    {
        private readonly ITTaskService _taskService;
        private readonly IMapper _mapper;

        public TTaskController(ITTaskService employeeService, IMapper mapper)
        {
            _taskService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TTaskResource>> GetAllAsync()
        {
            var employees = await _taskService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TTask>, IEnumerable<TTaskResource>>(employees);
            return resources;
        }
        
        [HttpGet("{Cemployee}")]
        [SwaggerOperation(Summary = "Get a task by Id")]
        [ProducesResponseType(typeof(TTaskResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _taskService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<TTask, TTaskResource>(result.Resource);
            return Ok(employeeResource);
        }
        
        [HttpPut("{Cemployee}")]
        [SwaggerOperation(Summary = "Update a task")]
        [ProducesResponseType(typeof(TTaskResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int Id, [FromBody] SaveTTaskResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveTTaskResource, TTask>(resource);
            var result = await _taskService.UpdateAsync(Id, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<TTask, TTaskResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a task")]
        [ProducesResponseType(typeof(TTaskResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTTaskResource resource)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var employee = _mapper.Map<SaveTTaskResource, TTask>(resource);
            var result = await _taskService.SaveAsync(employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<TTask, TTaskResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpDelete("{Cemployee}")]
        [SwaggerOperation(Summary = "Delete a task by Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _taskService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<TTask, TTaskResource>(result.Resource);

            return Ok(employeeResource);

        }
    }
}