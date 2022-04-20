using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class TaskProjectControlResource
    {
        public int Task_CTask { get; set; }
        public int ProjectControlId { get; set; }
        public int EmployeesId { get; set; }
        public int TTaskId { get; set; }
    }
}