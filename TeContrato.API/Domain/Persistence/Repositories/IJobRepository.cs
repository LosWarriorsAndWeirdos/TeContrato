using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> ListAsync();
        Task AddAsync(Job job);
        Task<Job> FindById(int id);
        void Update(Job job);
        void Remove(Job job);
    }
}