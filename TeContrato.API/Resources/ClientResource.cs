using System.Collections.Generic;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class ClientResource : UserResource
    {
        public int Cuser { get; set; }
        public string TBio { get; set; }
        public string TAddress { get; set; }
        public int CityId { get; set; }
    }
}
