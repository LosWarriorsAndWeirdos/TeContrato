using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class PostsResponse : BaseResponse<Posts>
    {
        public PostsResponse(Posts resource) : base(resource)
        {
        }

        public PostsResponse(string message) : base(message)
        {
        }
    }
}