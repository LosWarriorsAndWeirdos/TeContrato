using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class ControlEmployeesRepository : BaseRepository, IControlEmployeesRepository
    {
        public ControlEmployeesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(ControlEmployees controlEmployee)
        {
            await _context.ControlEmployees.AddAsync(controlEmployee);
        }

        public async Task AssignControlEmployee(int controlId, int employeeId)
        {
            ControlEmployees productTag = await FindByControlIdAndEmployeeId(controlId, employeeId);
            if (productTag == null)
            {
                productTag = new ControlEmployees { ProjectControlId = controlId, EmployeeId = employeeId };
                await AddAsync(productTag);
            }
        }

        public async Task<ControlEmployees> FindByControlIdAndEmployeeId(int controlId, int employeeId)
        {
            return await _context.ControlEmployees.FindAsync(controlId, employeeId);
        }

        public async Task<IEnumerable<ControlEmployees>> ListAsync()
        {
            return await _context.ControlEmployees
                .Include(pt => pt.CProjectControl)
                .Include(pt => pt.CEmployee)
                .ToListAsync();
        }

        public async Task<IEnumerable<ControlEmployees>> ListByControlIdAsync(int controlId)
        {
            return await _context.ControlEmployees
                .Where(pt => pt.ProjectControlId == controlId)
                .Include(pt => pt.CProjectControl)
                .Include(pt => pt.CEmployee)
                .ToListAsync();
        }

        public async Task<IEnumerable<ControlEmployees>> ListByEmployeeIdAsync(int employeeId)
        {
            return await _context.ControlEmployees
                .Where(pt => pt.EmployeeId == employeeId)
                .Include(pt => pt.CProjectControl)
                .Include(pt => pt.CEmployee)
                .ToListAsync();
        }

        public void Remove(ControlEmployees controlEmployee)
        {
            _context.ControlEmployees.Remove(controlEmployee);
        }

        public async Task UnassignControlEmployee(int controlId, int employeeId)
        {
            ControlEmployees productTag = await FindByControlIdAndEmployeeId(controlId, employeeId);
            if (productTag != null)
                Remove(productTag);
        }
    }
}
