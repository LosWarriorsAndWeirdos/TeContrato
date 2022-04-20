using System.Collections.Generic;

namespace TeContrato.API.Domain.Models
{
    public class Contractor : User
    {
        public int CContractor { get; set; }
        public string TBio { get; set; }
        public string NEducation { get; set; }
        public int Numphone { get; set; }
        public IList<Project> CProjects { get; set; }
    }
}
