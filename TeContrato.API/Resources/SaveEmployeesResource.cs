using System.ComponentModel.DataAnnotations;

namespace TeContrato.API.Resources
{
    public class SaveEmployeesResource
    {
        public string Nemployee { get; set; }
        public string Tposition { get; set; }
        public int Mpayment { get; set; }
        public string Tworks { get; set; }
    }
}