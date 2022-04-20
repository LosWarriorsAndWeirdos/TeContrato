using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class SaveProjectControlResource
    {
        public string Nproject { get; set; }
        public DateTime Dlastedited { get; set; }
        public int Qemployees { get; set; }
        public int Mbudget { get; set; }
        public int Qprogress { get; set; }
    }
}