using System.Collections.Generic;

namespace TeContrato.API.Domain.Models
{
    public class Client : User
    {
        public string TBio { get; set; }
        public string TAddress { get; set; }
        public City CCity { get; set; }
        public int CityId { get; set; }
        public IList<Project> CProjects { get; set; }
        
    }
}
