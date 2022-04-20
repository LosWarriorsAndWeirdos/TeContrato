using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Services.Communications
{
    public class ProjectControlResponse : BaseResponse<ProjectControl>
    {
        public ProjectControlResponse(ProjectControl resource) : base(resource)
        {
        }

        public ProjectControlResponse(string message) : base(message)
        {
        }
    }
}