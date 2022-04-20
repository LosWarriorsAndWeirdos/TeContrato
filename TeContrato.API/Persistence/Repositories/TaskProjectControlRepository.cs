using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class TaskProjectControlRepository : BaseRepository, ITaskProjectControlRepository
    {
        public TaskProjectControlRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TaskProjectControl>> ListAsync()
        {
            return await _context.TaskProjectControls.ToListAsync();
        }

        public async Task AddAsync(TaskProjectControl employees)
        {
            await _context.AddAsync(employees);
        }

        public async Task<TaskProjectControl> FindById(int id)
        {
            return await _context.TaskProjectControls.FindAsync(id);
        }

        public void Remove(TaskProjectControl employees)
        {
            _context.Remove(employees);
        }
        public void Update(TaskProjectControl employees)
        {
            _context.Update(employees);
        }
    }
}