using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface IProjectControlService
    {
        Task<IEnumerable<ProjectControl>> ListAsync();
        Task<ProjectControlResponse> GetByIdAsync(int id);
        Task<ProjectControlResponse> SaveAsync(ProjectControl city);
        Task<ProjectControlResponse> SaveAsync(int statusId, int projectId,ProjectControl city);

        Task<ProjectControlResponse> UpdateAsync(int id, ProjectControl city);
        Task<ProjectControlResponse> DeleteAsync(int id);
    }
}