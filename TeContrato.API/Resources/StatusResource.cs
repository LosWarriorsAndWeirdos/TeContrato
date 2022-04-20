using System.Collections.Generic;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class StatusResource
    {
        public int CStatus { get; set; }
        public string NStatus { get; set; }
        public IList<ProjectControl> CProjectControls { get; set; }
        public int ProjectControlId { get; set; }
    }
}