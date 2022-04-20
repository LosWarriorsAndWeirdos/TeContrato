using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface IBudgetRepository
    {
        Task<IEnumerable<Budget>> ListAsync();
        Task AddAsync(Budget employees);
        Task<Budget> FindById(int id);
        void Update(Budget employees);
        void Remove(Budget employees);
    }
}