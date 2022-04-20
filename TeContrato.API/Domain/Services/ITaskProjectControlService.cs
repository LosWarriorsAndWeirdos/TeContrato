using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface ITaskProjectControlService
    {
        Task<IEnumerable<TaskProjectControl>> ListAsync();
        Task<TaskProjectControlResponse> GetByIdAsync(int id);
        Task<TaskProjectControlResponse> SaveAsync(int projectControlId, int taskId, int employeeId, TaskProjectControl city);
        Task<TaskProjectControlResponse> UpdateAsync(int id, TaskProjectControl city);
        Task<TaskProjectControlResponse> DeleteAsync(int id);
    }
}