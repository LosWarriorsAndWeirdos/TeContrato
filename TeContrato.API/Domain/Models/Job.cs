using System.Collections.Generic;

namespace TeContrato.API.Domain.Models
{
    public class Job
    {
        public int Cjob { get; set; }
        public string Njob { get; set; }
        public string Tdescription { get; set; }
        public int EmployeeId { get; set; }
        
        public IList<Employees> CEmployee { get; set; }
    }
}