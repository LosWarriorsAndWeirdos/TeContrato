using System;
using System.Collections.Generic;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class BudgetResource
    {
        public int CBudget { get; set; }
        public string TDescription { get; set; }
        public float MMonto { get; set; }
        public DateTime DFecha { get; set; }
        public IList<Project> CProject { get; set; }
    }
}