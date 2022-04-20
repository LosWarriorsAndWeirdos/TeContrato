using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface ITTaskService
    {
        Task<IEnumerable<TTask>> ListAsync();
        Task<TTaskResponse> GetByIdAsync(int id);
        Task<TTaskResponse> SaveAsync(TTask city);
        Task<TTaskResponse> UpdateAsync(int id, TTask city);
        Task<TTaskResponse> DeleteAsync(int id);
    }
}