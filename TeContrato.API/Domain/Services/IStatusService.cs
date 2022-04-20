using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface IStatusService
    {
        Task<IEnumerable<Status>> ListAsync();
        Task<StatusResponse> GetByIdAsync(int id);
        Task<StatusResponse> SaveAsync(Status city);
        Task<StatusResponse> UpdateAsync(int id, Status city);
        Task<StatusResponse> DeleteAsync(int id);
    }
}