using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class ControlEmployeeResource
    {
        public int ControlEmployeesId { get; set; }
        public ProjectControl CProjectControl { get; set; }
        public int ProjectControlId { get; set; }
        public Employees CEmployee { get; set; }
        public int EmployeeId { get; set; }
    }
}