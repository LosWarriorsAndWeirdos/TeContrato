using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task AddAsync(City city)
        {
            await _context.AddAsync(city);
        }

        public async Task<City> FindById(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public void Remove(City city)
        {
            _context.Remove(city);
        }
        public void Update(City city)
        {
            _context.Update(city);
        }
    }
}
