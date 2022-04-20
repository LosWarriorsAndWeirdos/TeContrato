using System.Collections.Generic;

namespace TeContrato.API.Domain.Models
{
    public class TTask
    {
        public int TTaskId { get; set; }
        public string TTaskName { get; set; }
        
        public int TaskProjectControlId { get; set; }
        public IList<TaskProjectControl> CTaskProjectControl { get; set; }
    }
}