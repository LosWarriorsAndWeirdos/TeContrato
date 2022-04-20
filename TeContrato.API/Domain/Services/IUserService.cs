using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    //Una interfaz es para declarar algo que se va a usar, pero no se ha declarado todavía
    //Así como en C++ en clases que declarabas los métodos dentro e implementabas afuera
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> GetByIdAsync(int id);
    }
}
