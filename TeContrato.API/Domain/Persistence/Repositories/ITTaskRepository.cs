using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface ITTaskRepository
    {
        Task<IEnumerable<TTask>> ListAsync();
        Task AddAsync(TTask employees);
        Task<TTask> FindById(int id);
        void Update(TTask employees);
        void Remove(TTask employees);
    }
}