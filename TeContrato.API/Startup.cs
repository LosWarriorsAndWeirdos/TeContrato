using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Contexts;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Persistence.Repositories;
using TeContrato.API.Services;

namespace TeContrato.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddCors();
            services.AddControllers();

            // DbContext Configuration
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Dependency Injection Configuration
            //Cuando alguien haga referencia a IUserRepository, el instanciará a UserRepository

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IContractorRepository, ContractorRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IPostRepository, PostsRepository>();
            services.AddScoped<IEmployeeRepository, EmployeesRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IControlEmployeesRepository, ControlEmployeesRepository>();
            services.AddScoped<IProjectControlRepository, ProjectControlRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ITTaskRepository, TTaskRepository>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITaskProjectControlRepository, TaskProjectControlRepository>();
            
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IContractorService, ContractorService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IPostService, PostsService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IProjectControlService, ProjectControlService>();
            services.AddScoped<IControlEmployeesService, ControlEmployeesService>();
            services.AddScoped<ITTaskService, TTaskService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IBudgetService, BudgetService>();
            services.AddScoped<ITaskProjectControlService, TaskProjectControlService>();

            // Endpoints Case Conventions Configuration

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TeContrato.API", Version = "v1" });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TeContrato.API v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseCors(x => x.SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
