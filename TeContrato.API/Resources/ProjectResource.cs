using System;
using MySqlX.XDevAPI;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class ProjectResource
    {
        public string NProject { get; set; }
        public DateTime Dcreatedat { get; set; }
        public string Tdescription { get; set; }
        public int BudgetId { get; set; }
        public int ClientId { get; set; }
        public int ContractorId { get; set; }
    }
}