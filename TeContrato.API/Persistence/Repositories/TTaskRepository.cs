using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class TTaskRepository : BaseRepository, ITTaskRepository
    {
        public TTaskRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TTask>> ListAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task AddAsync(TTask employees)
        {
            await _context.AddAsync(employees);
        }

        public async Task<TTask> FindById(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public void Remove(TTask employees)
        {
            _context.Remove(employees);
        }
        public void Update(TTask employees)
        {
            _context.Update(employees);
        }
    }
}