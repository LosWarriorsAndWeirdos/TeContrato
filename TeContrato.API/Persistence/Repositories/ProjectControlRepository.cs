using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class ProjectControlRepository : BaseRepository, IProjectControlRepository
    {
        public ProjectControlRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProjectControl>> ListAsync()
        {
            return await _context.ProjectControls.ToListAsync();
        }

        public async Task AddAsync(ProjectControl projectControl)
        {
            await _context.AddAsync(projectControl);
        }

        public async Task<ProjectControl> FindById(int id)
        {
            return await _context.ProjectControls.FindAsync(id);
        }

        public void Remove(ProjectControl projectControl)
        {
            _context.Remove(projectControl);
        }
        public void Update(ProjectControl projectControl)
        {
            _context.Update(projectControl);
        }
    }
}