using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface IContractorRepository
    {
        Task<IEnumerable<Contractor>> ListAsync();
        Task AddAsync(Contractor contractor);
        Task<Contractor> FindById(int id);
        void Update(Contractor contractor);
        void Remove(Contractor contractor);
    }
}
