using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employees>> ListAsync();
        Task AddAsync(Employees employees);
        Task<Employees> FindById(int id);
        void Update(Employees employees);
        void Remove(Employees employees);
    }
}