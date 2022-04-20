using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class EmployeesResponse : BaseResponse<Employees>
    {
        public EmployeesResponse(Employees resource) : base(resource)
        {
        }

        public EmployeesResponse(string message) : base(message)
        {
        }
    }
}