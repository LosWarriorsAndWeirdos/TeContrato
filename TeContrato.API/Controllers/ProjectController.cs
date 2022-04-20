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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all Projects")]
        [ProducesResponseType(typeof(IEnumerable<JobResource>), 200)]
        public async Task<IEnumerable<ProjectResource>> GetAllAsync()
        {
            var project = await _projectService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(project);
            return resources;
        }
        
        [HttpGet("{Cproject}")]
        [SwaggerOperation(Summary = "Get a project by Id")]
        [ProducesResponseType(typeof(ProjectResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _projectService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a Project")]
        [ProducesResponseType(typeof(JobResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int clientId, int contractorId, int budgetId, [FromBody] SaveProjectResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var project = _mapper.Map<SaveProjectResource, Project>(resource);
            var result = await _projectService.SaveAsync(clientId, contractorId, budgetId, project);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }
        
        [HttpPut("{Cproject}")]
        [SwaggerOperation(Summary = "Update a project by Id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProjectResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var project = _mapper.Map<SaveProjectResource, Project>(resource);
            var result = await _projectService.UpdateAsync(id, project);

            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);

            return Ok(projectResource);
        }
        
        [HttpDelete("{Cproject}")]
        [SwaggerOperation(Summary = "Delete a Project")]
        [ProducesResponseType(typeof(CityResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }
    }
}
