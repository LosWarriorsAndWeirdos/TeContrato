using System.Collections.Generic;
using Google.Protobuf;

namespace TeContrato.API.Domain.Models
{
    public class ControlEmployees
    {
        public int ControlEmployeesId { get; set; }
        public ProjectControl CProjectControl { get; set; }
        public int ProjectControlId { get; set; }
        public Employees CEmployee { get; set; }
        public int EmployeeId { get; set; }
    }
}