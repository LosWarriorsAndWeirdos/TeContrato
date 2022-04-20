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
    public class ProjectControlController : ControllerBase
    {
        private readonly IProjectControlService _projectcontrolService;
        private readonly IMapper _mapper;

        public ProjectControlController(IProjectControlService projectcontrolService, IMapper mapper)
        {
            _projectcontrolService = projectcontrolService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all Project Controls")]
        [ProducesResponseType(typeof(IEnumerable<ProjectControlResource>), 200)]
        public async Task<IEnumerable<ProjectControlResource>> GetAllAsync()
        {
            var projectcontrol = await _projectcontrolService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ProjectControl>, IEnumerable<ProjectControlResource>>(projectcontrol);
            return resources;
        }
        
        [HttpGet("{Ccontrol}")]
        [SwaggerOperation(Summary = "Get a project-control by Id")]
        [ProducesResponseType(typeof(ProjectControlResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _projectcontrolService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectcontrolResource = _mapper.Map<ProjectControl, ProjectControlResource>(result.Resource);
            return Ok(projectcontrolResource);
        }
        
        [HttpPut("{Ccontrol}")]
        [SwaggerOperation(Summary = "Update a project-control by Id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProjectControlResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var projectcontrol = _mapper.Map<SaveProjectControlResource, ProjectControl>(resource);
            var result = await _projectcontrolService.UpdateAsync(id, projectcontrol);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectcontrolResource = _mapper.Map<ProjectControl, ProjectControlResource>(result.Resource);

            return Ok(projectcontrolResource);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a ProjectControl")]
        [ProducesResponseType(typeof(ProjectControlResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int statusId, int projectId,[FromBody] SaveProjectControlResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var projectC = _mapper.Map<SaveProjectControlResource, ProjectControl>(resource);
            var result = await _projectcontrolService.SaveAsync(statusId, projectId,projectC);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectCResource = _mapper.Map<ProjectControl, ProjectControlResource>(result.Resource);
            return Ok(projectCResource);
        }
        
        [HttpDelete("{Ccontrol}")]
        [SwaggerOperation(Summary = "Delete a project-control")]
        [ProducesResponseType(typeof(CityResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectcontrolService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var projectcontrolResource = _mapper.Map<ProjectControl, ProjectControlResource>(result.Resource);
            return Ok(projectcontrolResource);
        }
    }
}
