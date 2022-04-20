using System.Collections.Generic;

namespace TeContrato.API.Domain.Models
{
    //Los nombres de las clases se deben poner en en singular, ya que así es la regla, pero estos objetos irán
    //a una tabla de una BD, donde debe ser plural, por ello se debe agregar Microsoft.EntityFrameworkCore.Relational
    //y usar la propiedad .ToTable()
    public abstract class User
    {
        public int Cuser { get; set; }
        public string Nuser { get; set; }
        public int Cpassword { get; set; }
        public string Temail { get; set; }
        public int Cdni { get; set; }
        public string Nname { get; set; }
        public string Nlastname { get; set; }
        public int is_admin { get; set; }

        public IList<Posts> Posts { get; set; }

    }
}
