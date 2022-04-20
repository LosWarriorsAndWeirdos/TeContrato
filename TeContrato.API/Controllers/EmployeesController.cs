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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeesService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeesResource>> GetAllAsync()
        {
            var employees = await _employeeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Employees>, IEnumerable<EmployeesResource>>(employees);
            return resources;
        }
        
        [HttpGet("{Cemployee}")]
        [SwaggerOperation(Summary = "Get a employee by Id")]
        [ProducesResponseType(typeof(EmployeesResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _employeeService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employees, EmployeesResource>(result.Resource);
            return Ok(employeeResource);
        }
        
        [HttpPut("{Cemployee}")]
        [SwaggerOperation(Summary = "Update a employee")]
        [ProducesResponseType(typeof(EmployeesResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int Id, [FromBody] SaveEmployeesResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveEmployeesResource, Employees>(resource);
            var result = await _employeeService.UpdateAsync(Id, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employees, EmployeesResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a employee")]
        [ProducesResponseType(typeof(EmployeesResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int jobId, [FromBody] SaveEmployeesResource resource)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var employee = _mapper.Map<SaveEmployeesResource, Employees>(resource);
            var result = await _employeeService.SaveAsync(jobId, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employees, EmployeesResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpDelete("{Cemployee}")]
        [SwaggerOperation(Summary = "Delete a employee by Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Employees, EmployeesResource>(result.Resource);

            return Ok(employeeResource);

        }
    }
}