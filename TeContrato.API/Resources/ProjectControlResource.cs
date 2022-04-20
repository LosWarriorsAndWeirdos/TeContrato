using System;
using System.Collections.Generic;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class ProjectControlResource
    {
        public int Ccontrol { get; set; }
        public string Nproject { get; set; }
        
        public int CStatusId { get; set; }
        public DateTime Dlastedited { get; set; }
        public int Qemployees { get; set; }
        public int Mbudget { get; set; }
        public int Qprogress { get; set; }
        public int ProjectId { get; set; }
    }
}