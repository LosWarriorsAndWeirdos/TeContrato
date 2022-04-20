using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface IControlEmployeesRepository
    {
        Task<IEnumerable<ControlEmployees>> ListAsync();
        Task<IEnumerable<ControlEmployees>> ListByControlIdAsync(int controlId);
        Task<IEnumerable<ControlEmployees>> ListByEmployeeIdAsync(int employeeId);
        Task<ControlEmployees> FindByControlIdAndEmployeeId(int controlId, int employeeId);
        Task AddAsync(ControlEmployees controlEmployee);
        void Remove(ControlEmployees controlEmployee);
        Task AssignControlEmployee(int controlId, int employeeId);
        Task UnassignControlEmployee(int controlId, int employeeId);
    }
}