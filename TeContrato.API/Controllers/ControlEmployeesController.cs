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
    public class ControlEmployeesController : ControllerBase
    {
        private readonly IControlEmployeesService _controlemployeesService;
        private readonly IMapper _mapper;

        public ControlEmployeesController(IControlEmployeesService controlemployeesService, IMapper mapper)
        {
            _controlemployeesService = controlemployeesService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all Control-Employees")]
        [ProducesResponseType(typeof(IEnumerable<ControlEmployeeResource>), 200)]
        public async Task<IEnumerable<ControlEmployeeResource>> GetAllAsync()
        {
            var user = await _controlemployeesService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ControlEmployees>, IEnumerable<ControlEmployeeResource>>(user);
            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> AssignControlEmployee(int controlId, int employeeId)
        {
            var result = await _controlemployeesService.AssignControlEmployeeAsync(controlId, employeeId);

            if (!result.Success)
                return BadRequest(result.Message);

            var tagResource = _mapper.Map<Employees, Employees>(result.Resource.CEmployee);

            return Ok(tagResource);
        }

    }
}