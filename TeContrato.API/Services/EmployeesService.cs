using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeeRepository _employeesRepository;
        private readonly IJobRepository _jobRepository;
        public readonly IUnitOfWork _unitOfWork;
        
        public EmployeesService(IEmployeeRepository employeeRepository, IJobRepository jobRepository, IUnitOfWork unitOfWork)
        {
            _employeesRepository = employeeRepository;
            _jobRepository = jobRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeesResponse> DeleteAsync(int id)
        {
            var existingTag = await _employeesRepository.FindById(id);

            if (existingTag == null)
                return new EmployeesResponse("City not found");

            try
            {
                _employeesRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();
                return new EmployeesResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new EmployeesResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<EmployeesResponse> GetByIdAsync(int id)
        {
            var existingTag = await _employeesRepository.FindById(id);

            if (existingTag == null)
                return new EmployeesResponse("City not found");
            return new EmployeesResponse(existingTag);
        }
        
        public async Task<EmployeesResponse> SaveAsync(Employees city)
        {
            try
            {
                await _employeesRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new EmployeesResponse(city);
            }
            catch (Exception e)
            {
                return new EmployeesResponse($"Ocurrió un Error: {e.Message}");
            }
        }
        
        public async Task<EmployeesResponse> SaveAsync(int jobId, Employees employee)
        {
            var existingJob = await _jobRepository.FindById(jobId);

            if (existingJob == null)
                return new EmployeesResponse("Job not Found");
            
            try
            {
                employee.JobId = jobId;
                
                await _employeesRepository.AddAsync(employee);
                await _unitOfWork.CompleteAsync();

                return new EmployeesResponse(employee);
            }
            catch (Exception e)
            {
                return new EmployeesResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<Employees>> ListAsync()
        {
            return await _employeesRepository.ListAsync();

        }

        public async Task<EmployeesResponse> UpdateAsync(int id, Employees city)
        {
            var existingCity = await _employeesRepository.FindById(id);

            if (existingCity == null)
                return new EmployeesResponse("City not found");

            existingCity.Nemployee = city.Nemployee;
            existingCity.Tposition = city.Tposition;
            existingCity.Mpayment = city.Mpayment;
            existingCity.Tworks = city.Tworks;
            
            try
            {
                _employeesRepository.Update(existingCity);

                return new EmployeesResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new EmployeesResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}