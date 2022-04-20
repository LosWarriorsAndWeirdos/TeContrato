using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class JobResource
    {
        public int Cjob { get; set; }
        public string Njob { get; set; }
        public string Tdescription { get; set; }
        public int EmployeeId { get; set; }
    }
}