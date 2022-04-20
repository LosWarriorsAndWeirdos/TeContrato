using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class BudgetResponse : BaseResponse<Budget>
    {
        public BudgetResponse(Budget resource) : base(resource)
        {
        }

        public BudgetResponse(string message) : base(message)
        {
        }
    }
}