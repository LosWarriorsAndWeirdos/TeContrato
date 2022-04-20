using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class ProjectResponse : BaseResponse<Project>
    {
        public ProjectResponse(Project resource) : base(resource)
        {
        }

        public ProjectResponse(string message) : base(message)
        {
        }
    }
}