using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListAsync();
        Task AddAsync(City city);
        Task<City> FindById(int id);
        void Update(City city);
        void Remove(City city);

    }
}
