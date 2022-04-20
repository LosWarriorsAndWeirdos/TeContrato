using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class StatusRepository : BaseRepository, IStatusRepository
    {
        public StatusRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Status>> ListAsync()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task AddAsync(Status employees)
        {
            await _context.AddAsync(employees);
        }

        public async Task<Status> FindById(int id)
        {
            return await _context.Status.FindAsync(id);
        }

        public void Remove(Status employees)
        {
            _context.Remove(employees);
        }
        public void Update(Status employees)
        {
            _context.Update(employees);
        }
    }
}