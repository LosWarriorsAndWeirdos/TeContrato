using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface IProjectControlRepository
    {
        Task<IEnumerable<ProjectControl>> ListAsync();
        Task AddAsync(ProjectControl projectControl);
        Task<ProjectControl> FindById(int id);
        void Update(ProjectControl projectControl);
        void Remove(ProjectControl projectControl);
    }
}