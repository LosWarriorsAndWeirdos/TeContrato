using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<ProjectResponse> GetByIdAsync(int id);
        Task<ProjectResponse> SaveAsync(Project city);
        Task<ProjectResponse> SaveAsync(int clientId, int contractorId, int budgetId, Project city);

        Task<ProjectResponse> UpdateAsync(int id, Project city);
        Task<ProjectResponse> DeleteAsync(int id);
    }
}