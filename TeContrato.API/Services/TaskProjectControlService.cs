using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Services
{
    public class TaskProjectControlService : ITaskProjectControlService
    {
        private readonly ITaskProjectControlRepository _taskprojectcontrolRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITTaskRepository _taskRepository;
        private readonly IProjectControlRepository _projectControlRepository;
        public readonly IUnitOfWork _unitOfWork;
        
        public TaskProjectControlService(ITaskProjectControlRepository taskprojectcontrolRepository, IEmployeeRepository employeeRepository, ITTaskRepository taskRepository, IProjectControlRepository projectControlRepository,IUnitOfWork unitOfWork)
        {
            _taskprojectcontrolRepository = taskprojectcontrolRepository;
            _employeeRepository = employeeRepository;
            _taskRepository = taskRepository;
            _projectControlRepository = projectControlRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskProjectControlResponse> DeleteAsync(int id)
        {
            var existingTag = await _taskprojectcontrolRepository.FindById(id);

            if (existingTag == null)
                return new TaskProjectControlResponse("City not found");

            try
            {
                _taskprojectcontrolRepository.Remove(existingTag);
                return new TaskProjectControlResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new TaskProjectControlResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<TaskProjectControlResponse> GetByIdAsync(int id)
        {
            var existingTag = await _taskprojectcontrolRepository.FindById(id);

            if (existingTag == null)
                return new TaskProjectControlResponse("City not found");
            return new TaskProjectControlResponse(existingTag);
        }
        
        public async Task<TaskProjectControlResponse> SaveAsync(TaskProjectControl city)
        {
            try
            {
                await _taskprojectcontrolRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new TaskProjectControlResponse(city);
            }
            catch (Exception e)
            {
                return new TaskProjectControlResponse($"Ocurrió un Error: {e.Message}");
            }
        }
        
        public async Task<TaskProjectControlResponse> SaveAsync(int projectControlId, int taskId, int employeeId, TaskProjectControl taskProjectControl)
        {
            var existingProjectControl = await _projectControlRepository.FindById(projectControlId);
            var existingTask = await _taskRepository.FindById(taskId);
            var existingEmployee = await _employeeRepository.FindById(employeeId);

            if (existingProjectControl == null)
                return new TaskProjectControlResponse("Project-Control not found");
            
            if (existingTask == null)
                return new TaskProjectControlResponse("Task not found");

            if (existingEmployee == null)
                return new TaskProjectControlResponse("Employee not found");
            
            
            try
            {
                taskProjectControl.EmployeesId = employeeId;
                taskProjectControl.TTaskId = taskId;
                taskProjectControl.ProjectControlId = projectControlId;
                
                await _taskprojectcontrolRepository.AddAsync(taskProjectControl);
                await _unitOfWork.CompleteAsync();

                return new TaskProjectControlResponse(taskProjectControl);
            }
            catch (Exception e)
            {
                return new TaskProjectControlResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<TaskProjectControl>> ListAsync()
        {
            return await _taskprojectcontrolRepository.ListAsync();

        }

        public async Task<TaskProjectControlResponse> UpdateAsync(int id, TaskProjectControl city)
        {
            var existingCity = await _taskprojectcontrolRepository.FindById(id);

            if (existingCity == null)
                return new TaskProjectControlResponse("City not found");

            existingCity.CTasks = city.CTasks;

            try
            {
                _taskprojectcontrolRepository.Update(existingCity);

                return new TaskProjectControlResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new TaskProjectControlResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}