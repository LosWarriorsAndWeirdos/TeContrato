using System.Collections.Generic;

namespace TeContrato.API.Domain.Models
{
    public class Status
    {
        public int CStatus { get; set; }
        public string NStatus { get; set; }
        public IList<ProjectControl> CProjectControls { get; set; }
        
        public int ProjectControlId { get; set; }
    }
}