using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Services
{
    /*
     * La capa service se puede encargar de la lógica, pero para nada interactúa con la persistencia, es decir la BD, o al menos no directamente.
     * Necesita apoyarse en otra clase para que ese objeto sea el encargado de recuperar la info o guardarla, ese objeto es la capa de Persistencia.
     * Repository es un patrón de diseño que permite que haya una clase que se encarga de interactuar con la persistencia para manejar el tratamiento
     * de datos.
     */
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingCategory = await _userRepository.FindById(id);

            if (existingCategory == null)
                return new UserResponse("User Not Found");

            return new UserResponse(existingCategory);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
    }
}
