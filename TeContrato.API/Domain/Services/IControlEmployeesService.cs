using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface IControlEmployeesService
    {
        Task<IEnumerable<ControlEmployees>> ListAsync();
        Task<IEnumerable<ControlEmployees>> ListByControlIdAsync(int controlId);
        Task<IEnumerable<ControlEmployees>> ListByEmployeeIdAsync(int employeeId);
        Task<ControlEmployeesResponse> AssignControlEmployeeAsync(int controlId, int employeeId);
        Task<ControlEmployeesResponse> UnassignControlEmployeeAsync(int controlId, int employeeId);
    }
}