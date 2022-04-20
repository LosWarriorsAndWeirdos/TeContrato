using System.ComponentModel.DataAnnotations;

namespace TeContrato.API.Resources
{
    public class SaveClientResource : SaveUserResource
    {
        public string TBio { get; set; }
        public string TAddress { get; set; }
    }
}