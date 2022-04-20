using System;
using System.Collections.Generic;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class CityResource
    {
        public int CCity { get; set; }
        public string NCity { get; set; }
        public IList<Client> CClients { get; set; }    
    }
}
