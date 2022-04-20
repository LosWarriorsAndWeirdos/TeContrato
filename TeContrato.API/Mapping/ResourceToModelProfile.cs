using AutoMapper;
using TeContrato.API.Domain.Models;
using TeContrato.API.Resources;

namespace TeContrato.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveClientResource, Client>();
            CreateMap<SaveCityResource, City>();
            CreateMap<SaveContractorResource, Contractor>();
            CreateMap<SaveEmployeesResource, Employees>();
            CreateMap<SavePostsResource, Posts>();
            CreateMap<SaveProjectResource, Project>();
            CreateMap<SaveJobResource, Job>();
            CreateMap<SaveControlEmployeesResource, ControlEmployees>();
            CreateMap<SaveProjectControlResource, ProjectControl>();
            CreateMap<SaveTTaskResource, TTask>();
            CreateMap<SaveStatusResource, Status>();
            CreateMap<SaveBudgetResource, Budget>();
            CreateMap<TaskProjectControl, TaskProjectControlResource>();

        }
    }
}