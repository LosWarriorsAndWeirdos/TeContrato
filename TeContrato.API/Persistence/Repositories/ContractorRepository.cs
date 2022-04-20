using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class ContractorRepository : BaseRepository, IContractorRepository
    {

        public ContractorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Contractor>> ListAsync()
        {
            return await _context.Contractors.ToListAsync();
        }

        public async Task AddAsync(Contractor contractor)
        {
            await _context.AddAsync(contractor);
        }

        public async Task<Contractor> FindById(int id)
        {
            return await _context.Contractors.FindAsync(id);
        }

        public void Remove(Contractor contractor)
        {
            _context.Remove(contractor);
        }
        public void Update(Contractor contractor)
        {
            _context.Update(contractor);
        }
    }
}
