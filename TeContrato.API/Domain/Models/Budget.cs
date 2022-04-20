using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeContrato.API.Domain.Models
{
    public class Budget
    {
        [Key]
        public int CBudget { get; set; }
        public string TDescription { get; set; }
        public float MMonto { get; set; }
        public DateTime DFecha { get; set; }
        public IList<Project> CProject { get; set; }
    }
}