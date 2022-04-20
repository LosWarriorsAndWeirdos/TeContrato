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
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        private readonly IMapper _mapper;

        public BudgetController(IBudgetService employeeService, IMapper mapper)
        {
            _budgetService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BudgetResource>> GetAllAsync()
        {
            var employees = await _budgetService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Budget>, IEnumerable<BudgetResource>>(employees);
            return resources;
        }
        
        [HttpGet("{CBudget}")]
        [SwaggerOperation(Summary = "Get a budget by Id")]
        [ProducesResponseType(typeof(BudgetResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _budgetService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Budget, BudgetResource>(result.Resource);
            return Ok(employeeResource);
        }
        
        [HttpPut]
        [SwaggerOperation(Summary = "Update a budget")]
        [ProducesResponseType(typeof(BudgetResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int Id, [FromBody] SaveBudgetResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employee = _mapper.Map<SaveBudgetResource, Budget>(resource);
            var result = await _budgetService.UpdateAsync(Id, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Budget, BudgetResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a budget")]
        [ProducesResponseType(typeof(BudgetResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveBudgetResource resource)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var employee = _mapper.Map<SaveBudgetResource, Budget>(resource);
            var result = await _budgetService.SaveAsync(employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Budget, BudgetResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpDelete("{CBudget}")]
        [SwaggerOperation(Summary = "Delete a budget by Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _budgetService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var employeeResource = _mapper.Map<Budget, BudgetResource>(result.Resource);
            return Ok(employeeResource);

        }
    }
}