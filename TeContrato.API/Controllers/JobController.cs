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
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public JobController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all Jobs")]
        [ProducesResponseType(typeof(IEnumerable<JobResource>), 200)]
        public async Task<IEnumerable<JobResource>> GetAllAsync()
        {
            var job = await _jobService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Job>, IEnumerable<JobResource>>(job);
            return resources;
        }
        
        [HttpGet("{Cjob}")]
        [SwaggerOperation(Summary = "Get a job by Id")]
        [ProducesResponseType(typeof(JobResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _jobService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Job, JobResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        [HttpPut("{Cjob}")]
        [SwaggerOperation(Summary = "Update a job by Id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveJobResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var job = _mapper.Map<SaveJobResource, Job>(resource);
            var result = await _jobService.UpdateAsync(id, job);

            if (!result.Success)
                return BadRequest(result.Message);

            var jobResource = _mapper.Map<Job, JobResource>(result.Resource);

            return Ok(jobResource);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a Job")]
        [ProducesResponseType(typeof(JobResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveJobResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var job = _mapper.Map<SaveJobResource, Job>(resource);
            var result = await _jobService.SaveAsync(job);

            if (!result.Success)
                return BadRequest(result.Message);

            var jobResource = _mapper.Map<Job, JobResource>(result.Resource);
            return Ok(jobResource);
        }
        
        [HttpDelete("{Cjob}")]
        [SwaggerOperation(Summary = "Delete a Job")]
        [ProducesResponseType(typeof(CityResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _jobService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var jobResource = _mapper.Map<Job, JobResource>(result.Resource);
            return Ok(jobResource);
        }
    }
}
