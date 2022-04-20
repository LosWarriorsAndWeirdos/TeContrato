using System;

namespace TeContrato.API.Resources
{
    public class SaveBudgetResource
    {
        public string TDescription { get; set; }
        public float MMonto { get; set; }
        public DateTime DFecha { get; set; }
    }
}