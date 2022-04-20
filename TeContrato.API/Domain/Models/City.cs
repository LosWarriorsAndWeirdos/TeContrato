using System.Collections.Generic;
using Google.Protobuf;

namespace TeContrato.API.Domain.Models
{
    public class City
    {
        public int CCity { get; set; }
        public string NCity { get; set; }
        public IList<Client> CClients { get; set; }
    }
}
