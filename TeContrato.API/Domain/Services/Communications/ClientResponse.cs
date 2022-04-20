using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class ClientResponse : BaseResponse<Client>
    {
        public ClientResponse(Client resource) : base(resource)
        {
        }

        public ClientResponse(string message) : base(message)
        {
        }
    }
}
