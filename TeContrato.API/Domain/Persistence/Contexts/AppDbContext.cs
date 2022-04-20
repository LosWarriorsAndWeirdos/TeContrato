using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeContrato.API.Extensions;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } //Set = Conjunto. Por eso recomienda Categories, porque las tablas (categories), representa un conjunto
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ControlEmployees> ControlEmployees { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectControl> ProjectControls { get; set; }
        public DbSet<TTask> Tasks { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TaskProjectControl> TaskProjectControls { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<User>().ToTable("User");
            builder.Entity<Client>().ToTable("User").HasBaseType<User>();
            builder.Entity<Contractor>().ToTable("User").HasBaseType<User>();
            builder.Entity<City>().ToTable("Cities");
            builder.Entity<Project>().ToTable("Projects");
            builder.Entity<Posts>().ToTable("Posts");
            builder.Entity<Employees>().ToTable("Employees");
            builder.Entity<Job>().ToTable("Jobs");
            builder.Entity<ProjectControl>().ToTable("ProjectControls");
            builder.Entity<ControlEmployees>().ToTable("ControlEmployees");
            builder.Entity<TTask>().ToTable("Tasks");
            builder.Entity<Status>().ToTable("Status");
            builder.Entity<Budget>().ToTable("Budget");
            builder.Entity<TaskProjectControl>().ToTable("TaskProjectControl");

            builder.Entity<TaskProjectControl>().HasKey(p => p.Task_CTask);

            builder.Entity<TaskProjectControl>()
                .HasOne(p => p.CEmployee)
                .WithMany(p => p.CTaskProjectControl)
                .HasForeignKey(p => p.EmployeesId);
            
            builder.Entity<TaskProjectControl>().HasData
            (new TaskProjectControl
                {
                    Task_CTask = 1,
                    ProjectControlId = 1,
                    EmployeesId = 1,
                    TTaskId = 1
                }
            );

            builder.Entity<Status>().HasKey(p => p.CStatus);
            builder.Entity<Status>().Property(p => p.NStatus);
            builder.Entity<Status>()
                .HasMany(p => p.CProjectControls)
                .WithOne(p => p.CStatus)
                .HasForeignKey(p => p.CStatusId);
            
            builder.Entity<Status>().HasData
            (new Status
                {
                    CStatus = 1,
                    NStatus = "Incomplete"
                }
            );
            
            builder.Entity<Status>().HasData
            (new Status
                {
                    CStatus = 2,
                    NStatus = "Completed"
                }
            );

            builder.Entity<Budget>().HasKey(p => p.CBudget);
            builder.Entity<Budget>().Property(p => p.DFecha);
            builder.Entity<Budget>().Property(p => p.MMonto);
            builder.Entity<Budget>().Property(p => p.TDescription);

            builder.Entity<Budget>()
                .HasMany(p => p.CProject)
                .WithOne(p => p.CBudget)
                .HasForeignKey(p => p.BudgetId);

            builder.Entity<Budget>().HasData(
                new Budget
                {
                    CBudget = 1,
                    TDescription = "Se necesita ladrillos y cemento",
                    MMonto = 100,
                    DFecha = DateTime.Now
                });


            builder.Entity<TTask>().HasKey(p => p.TTaskId);
            builder.Entity<TTask>().Property(p => p.TTaskName);

            builder.Entity<TTask>()
                .HasMany(p => p.CTaskProjectControl)
                .WithOne(p => p.CTasks)
                .HasForeignKey(p => p.TTaskId);

            builder.Entity<TTask>().HasData(
                new TTask
                {
                    TTaskId = 1,
                    TTaskName = "Romper la pared debajo del caño",
                    TaskProjectControlId = 1
                });


            builder.Entity<ControlEmployees>().HasKey(p => new {p.EmployeeId, p.ProjectControlId});

            builder.Entity<ControlEmployees>()
                .HasOne(p => p.CEmployee)
                .WithMany(t => t.CControlEmployees)
                .HasForeignKey(id => id.EmployeeId);

            builder.Entity<ControlEmployees>()
                .HasOne(p => p.CProjectControl)
                .WithMany(q => q.CControlEmployees)
                .HasForeignKey(id => id.ProjectControlId);

            builder.Entity<ControlEmployees>().HasData
            (new ControlEmployees
                {
                    ControlEmployeesId = 1,
                    ProjectControlId = 1,
                    EmployeeId = 1
                }
            );
            
            builder.Entity<User>().HasKey(p => p.Cuser);
            builder.Entity<User>().Property(p => p.Cuser).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Cpassword).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Temail).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Cdni).IsRequired().HasMaxLength(8);
            builder.Entity<User>().Property(p => p.Nname).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Nlastname).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.is_admin).IsRequired();
            builder.Entity<User>()
                .HasDiscriminator<int>("Tipo de Usuario")
                .HasValue<Client>(1)
                .HasValue<Contractor>(2);
            
            builder.Entity<User>()
                .HasMany(p => p.Posts)
                .WithOne(q => q.CUser)
                .HasForeignKey(post => post.UserId);

            builder.Entity<Client>().Property(p => p.TBio).IsRequired().HasMaxLength(50);
            builder.Entity<Client>().Property(p => p.TAddress).IsRequired().HasMaxLength(50);
            builder.Entity<Client>().Property(p => p.Nlastname);
            builder.Entity<Client>()
                .HasOne(p => p.CCity)
                .WithMany(q => q.CClients)
                .HasForeignKey(key => key.CityId);

            builder.Entity<Client>().HasData
                (new Client
                {
                    Cuser = 1,
                    CityId = 1,
                    Nuser = "JuanDelbarrio",
                    Cpassword = 1234,
                    Temail = "juan@xyz.com",
                    Cdni = 12345678,
                    Nname = "Juan",
                    Nlastname = "Perez",
                    is_admin = 1,
                    Posts = null,
                    TBio ="Residente en La Molina",
                    TAddress = "La capilla lote 8",
                });
            

            builder.Entity<City>().HasKey(p => p.CCity);
            builder.Entity<City>().Property(p => p.NCity).IsRequired().HasMaxLength(30);

            builder.Entity<City>().HasData
            (new City
                {
                    CCity = 1,
                    NCity = "Lima"
                }
            );

            builder.Entity<Contractor>().Property(p => p.TBio);
            builder.Entity<Contractor>().Property(p => p.NEducation).HasMaxLength(50);
            builder.Entity<Contractor>().Property(p => p.Numphone).HasMaxLength(50);
            
            builder.Entity<Contractor>().HasData
            (new Contractor
            {
                Cuser = 2,
                Nuser = "JohnDeConfianza",
                Cpassword = 1234,
                Temail = "john@xyz.com",
                Cdni = 87654321,
                Nname = "John",
                Nlastname = "Juarez",
                is_admin = 1,
                TBio ="Trabajador",
                NEducation = "Recoleta",
                Numphone = 999888777
            });

            builder.Entity<Project>().HasKey(p => p.Cproject);
            builder.Entity<Project>().Property(p => p.Nproject);
            builder.Entity<Project>().Property(p => p.Created_at);
            builder.Entity<Project>().Property(p => p.Tdescription);
            builder.Entity<Project>().Property(p => p.Mbudget);
            builder.Entity<Project>()
                .HasOne(p => p.CContractor)
                .WithMany(q => q.CProjects)
                .HasForeignKey(id => id.ContractorId);
            builder.Entity<Project>()
                .HasOne(p => p.CClient)
                .WithMany(q => q.CProjects)
                .HasForeignKey(id => id.ClientId);
            builder.Entity<Project>()
                .HasOne(p => p.CBudget)
                .WithMany(p => p.CProject)
                .HasForeignKey(p => p.BudgetId);

            builder.Entity<Project>().HasData
            (new Project
                {
                    Cproject = 1,
                    Nproject = "Arreglo de cocina",
                    Created_at = DateTime.Now,
                    Tdescription = "Arreglo de cocina en mi restaurant",
                    ContractorId = 2,
                    ClientId = 1,
                    BudgetId = 1
                }
            );
            
            builder.Entity<Posts>().HasKey(p => p.Cposts);
            builder.Entity<Posts>().Property(p => p.Ntitle);
            builder.Entity<Posts>().Property(p => p.Tbody);
            builder.Entity<Posts>().Property(p => p.Created_at);
            builder.Entity<Posts>().Property(p => p.Mbudget);
            builder.Entity<Posts>().Property(p => p.Views);
            builder.Entity<Posts>().Property(p => p.Pic);

            builder.Entity<Posts>().HasData
            (new Posts
                {
                    Cposts = 1,
                    Ntitle = "Desperfecto en mi cocina",
                    Tbody = "Necesito a alguien que me ayude con mi cocina",
                    Created_at = DateTime.Now,
                    Mbudget = 100,
                    Views = 3,
                    Pic = 2,
                    UserId = 1
                }
            );
            
            builder.Entity<Employees>().HasKey(p => p.Cemployee);
            builder.Entity<Employees>().Property(p => p.Nemployee);
            builder.Entity<Employees>().Property(p => p.Tposition);
            builder.Entity<Employees>().Property(p => p.Mpayment);
            builder.Entity<Employees>().Property(p => p.Tworks);

            builder.Entity<Employees>()
               .HasOne(p => p.Cjob)
               .WithMany(q => q.CEmployee);

            builder.Entity<Employees>().HasData
            (new Employees
                {
                    Cemployee = 1,
                    Nemployee = "Jose",
                    Tposition = "trabajador",
                    Mpayment = 50,
                    Tworks = "Gasfiteria", //???
                    JobId = 1
                }
            );

            builder.Entity<Job>().HasKey(p=>p.Cjob);
            builder.Entity<Job>().Property(p => p.Njob);
            builder.Entity<Job>().Property(p => p.Tdescription);
            builder.Entity<Job>()
              .HasMany(q => q.CEmployee)
              .WithOne(p => p.Cjob)
              .HasForeignKey(id => id.JobId);

            builder.Entity<Job>().HasData
            (new Job
                {
                    Cjob = 1,
                    Njob = "Gasfitería",
                    Tdescription = "Gasfitería",
                    EmployeeId = 1
                }
            );

            builder.Entity<ProjectControl>().HasKey(p => p.Ccontrol);
            builder.Entity<ProjectControl>().Property(p => p.Nproject);
            builder.Entity<ProjectControl>().Property(p => p.Dlastedited);
            builder.Entity<ProjectControl>().Property(p => p.Qemployees);
            builder.Entity<ProjectControl>().Property(p => p.Mbudget);
            builder.Entity<ProjectControl>().Property(p => p.Qprogress);

            builder.Entity<ProjectControl>()
                .HasOne(p => p.CProject)
                .WithOne(p => p.CProjectControl);

            builder.Entity<ProjectControl>().HasData
            (new ProjectControl
                {
                    Ccontrol = 1,
                    Nproject = "Control de Proyecto",
                    CStatusId = 1,
                    Dlastedited = DateTime.Now,
                    Qemployees = 3,
                    Mbudget = 100,
                    Qprogress = 50,
                    ProjectId = 1
                }
            );
        }
    }
}
