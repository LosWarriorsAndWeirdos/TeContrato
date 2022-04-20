using AutoMapper;
using TeContrato.API.Domain.Models;
using TeContrato.API.Resources;

namespace TeContrato.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<City, CityResource>();
            CreateMap<Client, ClientResource>();
            CreateMap<Contractor, ContractorResource>();
            CreateMap<Project, ProjectResource>();
            CreateMap<Posts, PostsResource>();
            CreateMap<Employees, EmployeesResource>();
            CreateMap<Job, JobResource>();
            CreateMap<ControlEmployees, ControlEmployeeResource>();
            CreateMap<ProjectControl, ProjectControlResource>();
            CreateMap<TTask, TTaskResource>();
            CreateMap<Status, StatusResource>();
            CreateMap<Budget, BudgetResource>();
            CreateMap<TaskProjectControl, TaskProjectControlResource>();

        }
    }
}
