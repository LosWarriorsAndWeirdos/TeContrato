using System;

namespace TeContrato.API.Domain.Models
{
    public class Project
    {
        public int Cproject { get; set; }
        public string Nproject { get; set; }
        public DateTime Created_at { get; set; }
        public string Tdescription { get; set; }
        public Contractor CContractor { get; set; }
        public int ContractorId { get; set; }
        public Client CClient { get; set; }
        public int ClientId { get; set; }
        public int Mbudget { get; set; }
        public ProjectControl CProjectControl { get; set; }
        public Budget CBudget { get; set; }
        
        public int BudgetId { get; set; }
    }
}
