using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class TaskProjectControlController : ControllerBase
    {
        private readonly ITaskProjectControlService _controlemployeesService;
        private readonly IMapper _mapper;

        public TaskProjectControlController(ITaskProjectControlService controlemployeesService, IMapper mapper)
        {
            _controlemployeesService = controlemployeesService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all Control-Employees")]
        [ProducesResponseType(typeof(IEnumerable<TaskProjectControlResource>), 200)]
        public async Task<IEnumerable<TaskProjectControlResource>> GetAllAsync()
        {
            var user = await _controlemployeesService.ListAsync();
            var resources = _mapper.Map<IEnumerable<TaskProjectControl>, IEnumerable<TaskProjectControlResource>>(user);
            return resources;
        }
        
        [HttpPost]
        [SwaggerOperation(Summary = "Create a Task-Project-Control")]
        [ProducesResponseType(typeof(TaskProjectControl), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int projectControlId, int taskId, int employeeId, [FromBody] SaveTaskProjectControlResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var project = _mapper.Map<SaveTaskProjectControlResource, TaskProjectControl>(resource);
            var result = await _controlemployeesService.SaveAsync(projectControlId, taskId, employeeId, project);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<TaskProjectControl, TaskProjectControlResource>(result.Resource);
            return Ok(projectResource);
        }

    }
}