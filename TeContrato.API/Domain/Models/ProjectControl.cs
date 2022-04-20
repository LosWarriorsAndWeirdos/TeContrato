using System;
using System.Collections.Generic;

namespace TeContrato.API.Domain.Models
{
    public class ProjectControl
    {
        public int Ccontrol { get; set; }
        public string Nproject { get; set; }
        public int CStatusId { get; set; }
        public Status CStatus { get; set; }
        public DateTime Dlastedited { get; set; }
        public int Qemployees { get; set; }
        public int Mbudget { get; set; }
        public int Qprogress { get; set; }
        public Project CProject { get; set; }
        public int ProjectId { get; set; }
        public IList<ControlEmployees> CControlEmployees { get; set; }
    }
}