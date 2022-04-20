using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> ListAsync();
        Task AddAsync(Status employees);
        Task<Status> FindById(int id);
        void Update(Status employees);
        void Remove(Status employees);
    }
}