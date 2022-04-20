using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class JobRepository : BaseRepository, IJobRepository
    {
        public JobRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Job>> ListAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task AddAsync(Job job)
        {
            await _context.AddAsync(job);
        }

        public async Task<Job> FindById(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public void Remove(Job job)
        {
            _context.Remove(job);
        }
        public void Update(Job job)
        {
            _context.Update(job);
        }
    }
}