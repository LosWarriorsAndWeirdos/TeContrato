using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public abstract class SaveUserResource
    {
        public string Nuser { get; set; }
        public int Cpassword { get; set; }
        public string Temail { get; set; }
        public int Cdni { get; set; }
        public string Nname { get; set; }
        public string Nlastname { get; set; }
        public int is_admin { get; set; }
    }
}
