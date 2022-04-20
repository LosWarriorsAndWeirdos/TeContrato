using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface IBudgetService
    {
        Task<IEnumerable<Budget>> ListAsync();
        Task<BudgetResponse> GetByIdAsync(int id);
        Task<BudgetResponse> SaveAsync(Budget city);
        Task<BudgetResponse> UpdateAsync(int id, Budget city);
        Task<BudgetResponse> DeleteAsync(int id);
    }
}