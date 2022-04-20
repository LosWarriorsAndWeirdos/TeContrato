using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> ListAsync();
        Task<JobResponse> GetByIdAsync(int id);
        Task<JobResponse> SaveAsync(Job city);
        Task<JobResponse> UpdateAsync(int id, Job city);
        Task<JobResponse> DeleteAsync(int id);
    }
}