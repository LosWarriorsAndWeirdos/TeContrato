using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task AddAsync(Project project);
        Task<Project> FindById(int id);
        void Update(Project project);
        void Remove(Project project);
    }
}