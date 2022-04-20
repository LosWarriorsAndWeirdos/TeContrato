using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class EmployeesRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employees>> ListAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task AddAsync(Employees employees)
        {
            await _context.AddAsync(employees);
        }

        public async Task<Employees> FindById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public void Remove(Employees employees)
        {
            _context.Remove(employees);
        }
        public void Update(Employees employees)
        {
            _context.Update(employees);
        }
    }
}