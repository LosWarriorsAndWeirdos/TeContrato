using System.Collections.Generic;

namespace TeContrato.API.Domain.Models
{
    public class TaskProjectControl
    {
        public int Task_CTask { get; set; }
        public ProjectControl CProjectControl { get; set; }
        public int ProjectControlId { get; set; }
        public Employees CEmployee { get; set; }
        public int EmployeesId { get; set; }
        public TTask CTasks { get; set; }
        public int TTaskId { get; set; }
        
    }
}