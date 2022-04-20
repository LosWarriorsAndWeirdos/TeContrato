using System;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class SaveProjectResource
    {
        public string NProject { get; set; }
        public DateTime Dcreatedat { get; set; }
        public string Tdescription { get; set; }
    }
}