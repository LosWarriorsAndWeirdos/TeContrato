using System.Collections.Generic;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class EmployeesResource
    {
        public int Cemployee { get; set; }
        public string Nemployee { get; set; }
        public string Tposition { get; set; }
        public int Mpayment { get; set; }
        public string Tworks { get; set; }
        public int JobId { get; set; }
        public IList<ControlEmployees> CControlEmployees { get; set; }
        public IList<TaskProjectControl> CTaskProjectControl { get; set; }
    }
}