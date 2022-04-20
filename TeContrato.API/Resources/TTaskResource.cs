﻿using System.Collections.Generic;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class TTaskResource
    {
        public int TTaskId { get; set; }
        public string TTaskName { get; set; }
        
        public int TaskProjectControlId { get; set; }
        public IList<TaskProjectControl> CTaskProjectControl { get; set; }
    }
}