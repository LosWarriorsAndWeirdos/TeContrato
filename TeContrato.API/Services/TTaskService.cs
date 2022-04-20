using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Services
{
    public class TTaskService : ITTaskService
    {
        private readonly ITTaskRepository _ttaskRepository;
        public readonly IUnitOfWork _unitOfWork;
        
        public TTaskService(ITTaskRepository ttaskRepository, IUnitOfWork unitOfWork)
        {
            _ttaskRepository = ttaskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TTaskResponse> DeleteAsync(int id)
        {
            var existingTag = await _ttaskRepository.FindById(id);

            if (existingTag == null)
                return new TTaskResponse("Task not found");

            try
            {
                _ttaskRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();
                return new TTaskResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new TTaskResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<TTaskResponse> GetByIdAsync(int id)
        {
            var existingTag = await _ttaskRepository.FindById(id);

            if (existingTag == null)
                return new TTaskResponse("Task not found");
            return new TTaskResponse(existingTag);
        }
        
        public async Task<TTaskResponse> SaveAsync(TTask city)
        {
            try
            {
                await _ttaskRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new TTaskResponse(city);
            }
            catch (Exception e)
            {
                return new TTaskResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<TTask>> ListAsync()
        {
            return await _ttaskRepository.ListAsync();

        }

        public async Task<TTaskResponse> UpdateAsync(int id, TTask city)
        {
            var existingCity = await _ttaskRepository.FindById(id);

            if (existingCity == null)
                return new TTaskResponse("Task not found");

            existingCity.TTaskName = city.TTaskName;

            try
            {
                _ttaskRepository.Update(existingCity);

                return new TTaskResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new TTaskResponse($"An error ocurred while updating the task: {ex.Message}");
            }

        }
    }
}