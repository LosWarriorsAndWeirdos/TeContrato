using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface ITaskProjectControlRepository
    {
        Task<IEnumerable<TaskProjectControl>> ListAsync();
        Task AddAsync(TaskProjectControl employees);
        Task<TaskProjectControl> FindById(int id);
        void Update(TaskProjectControl employees);
        void Remove(TaskProjectControl employees);
    }
}