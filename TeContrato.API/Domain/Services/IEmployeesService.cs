using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employees>> ListAsync();
        Task<EmployeesResponse> GetByIdAsync(int id);
        Task<EmployeesResponse> SaveAsync(Employees city);
        Task<EmployeesResponse> SaveAsync(int jobId, Employees city);

        Task<EmployeesResponse> UpdateAsync(int id, Employees city);
        Task<EmployeesResponse> DeleteAsync(int id);
    }
}