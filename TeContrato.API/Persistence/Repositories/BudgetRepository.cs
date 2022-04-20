using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;

namespace TeContrato.API.Persistence.Repositories
{
    public class BudgetRepository : BaseRepository, IBudgetRepository
    {
        public BudgetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Budget>> ListAsync()
        {
            return await _context.Budgets.ToListAsync();
        }

        public async Task AddAsync(Budget employees)
        {
            await _context.AddAsync(employees);
        }

        public async Task<Budget> FindById(int id)
        {
            return await _context.Budgets.FindAsync(id);
        }

        public void Remove(Budget employees)
        {
            _context.Budgets.Remove(employees);
        }
        public void Update(Budget employees)
        {
            _context.Budgets.Update(employees);
        }
    }
}