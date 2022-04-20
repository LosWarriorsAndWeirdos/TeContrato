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
    [Route("/api/Contractors/[controller]/")]
    public class ContractorsController : ControllerBase
    {
        private readonly IContractorService _contractorService;
        private readonly IMapper _mapper;

        public ContractorsController(IContractorService contractorService, IMapper mapper)
        {
            _contractorService = contractorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContractorResource>> GetAllAsync()
        {
            var tags = await _contractorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Contractor>, IEnumerable<ContractorResource>>(tags) ;
            return resources;
        }
        
        [HttpGet("{Ccontractor}")]
        [SwaggerOperation(Summary = "Get a contractor by Id")]
        [ProducesResponseType(typeof(ContractorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _contractorService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var contractorResource = _mapper.Map<Contractor, ContractorResource>(result.Resource);
            return Ok(contractorResource);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a Contractor")]
        [ProducesResponseType(typeof(ContractorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveContractorResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var contractor = _mapper.Map<SaveContractorResource, Contractor>(resource);
            var result = await _contractorService.SaveAsync(contractor);

            if (!result.Success)
                return BadRequest(result.Message);

            var contractorResource = _mapper.Map<Contractor, ContractorResource>(result.Resource);
            return Ok(contractorResource);
        }
        
        [HttpPut("{Ccontractor}")]
        [SwaggerOperation(Summary = "Update a contractor by Id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveContractorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var contractor = _mapper.Map<SaveContractorResource, Contractor>(resource);
            var result = await _contractorService.UpdateAsync(id, contractor);

            if (!result.Success)
                return BadRequest(result.Message);

            var contractorResource = _mapper.Map<Contractor, ContractorResource>(result.Resource);

            return Ok(contractorResource);
        }

        [HttpDelete("{Ccontractor}")]
        [SwaggerOperation(Summary = "Delete a contractor by Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _contractorService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var contractorResource = _mapper.Map<Contractor, ContractorResource>(result.Resource);

            return Ok(contractorResource);

        }
    }
}
