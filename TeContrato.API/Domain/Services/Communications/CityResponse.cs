using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class CityResponse : BaseResponse<City>
    {
        public CityResponse(City resource) : base(resource)
        {
            
        }

        public CityResponse(string message) : base(message)
        {
            
        }
    }
}
