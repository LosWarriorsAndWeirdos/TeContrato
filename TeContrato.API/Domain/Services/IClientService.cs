using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> ListAsync();
        Task<ClientResponse> GetByIdAsync(int id);
        Task<ClientResponse> SaveAsync(int cityId, Client client);
        Task<ClientResponse> UpdateAsync(int id, Client client);
        Task<ClientResponse> DeleteAsync(int id);
    }
}
