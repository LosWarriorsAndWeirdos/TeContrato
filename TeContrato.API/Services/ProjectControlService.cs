using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Services
{
    public class ProjectControlService : IProjectControlService
    {
        private readonly IProjectControlRepository _cityRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IProjectRepository _projectRepository;
        public readonly IUnitOfWork _unitOfWork;


        public ProjectControlService(IProjectControlRepository contractorRepository, IStatusRepository statusRepository, IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = contractorRepository;
            _statusRepository = statusRepository;
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProjectControlResponse> DeleteAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new ProjectControlResponse("City not found");

            try
            {
                _cityRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();
                return new ProjectControlResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new ProjectControlResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<ProjectControlResponse> GetByIdAsync(int id)
        {
            var existingTag = await _cityRepository.FindById(id);

            if (existingTag == null)
                return new ProjectControlResponse("City not found");
            return new ProjectControlResponse(existingTag);
        }
        
        public async Task<ProjectControlResponse> SaveAsync(ProjectControl city)
        {
            try
            {
                await _cityRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new ProjectControlResponse(city);
            }
            catch (Exception e)
            {
                return new ProjectControlResponse($"Ocurrió un Error: {e.Message}");
            }
        }
        
        public async Task<ProjectControlResponse> SaveAsync(int statusId, int projectId,ProjectControl projectControl)
        {
            var existingStatus = await _statusRepository.FindById(statusId);
            var existingProject = await _projectRepository.FindById(projectId);

            if (existingProject == null)
            {
                return new ProjectControlResponse("Project not found");
            }

            if (existingStatus == null)
            {
                return new ProjectControlResponse("Status not found");
            }
            
            try
            {
                projectControl.CStatusId = statusId;
                projectControl.ProjectId = projectId;
                await _cityRepository.AddAsync(projectControl);
                await _unitOfWork.CompleteAsync();
                return new ProjectControlResponse(projectControl);
            }
            catch (Exception e)
            {
                return new ProjectControlResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<ProjectControl>> ListAsync()
        {
            return await _cityRepository.ListAsync();

        }

        public async Task<ProjectControlResponse> UpdateAsync(int id, ProjectControl city)
        {
            var existingCity = await _cityRepository.FindById(id);

            if (existingCity == null)
                return new ProjectControlResponse("City not found");

            existingCity.Nproject = city.Nproject;
            existingCity.Qemployees = city.Qemployees;
            existingCity.Mbudget= city.Mbudget;
            existingCity.Qprogress= city.Qprogress;




            try
            {
                _cityRepository.Update(existingCity);

                return new ProjectControlResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new ProjectControlResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}