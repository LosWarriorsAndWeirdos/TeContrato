using System.ComponentModel.DataAnnotations;

namespace TeContrato.API.Resources
{
    public class SaveContractorResource : SaveUserResource
    {
        public string TBio { get; set; }
        public string NEducation { get; set; }
        public int Numphone { get; set; }
    }
}