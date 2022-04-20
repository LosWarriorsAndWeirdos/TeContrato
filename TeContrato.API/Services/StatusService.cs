using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        public readonly IUnitOfWork _unitOfWork;
        
        public StatusService(IStatusRepository statusRepository, IUnitOfWork unitOfWork)
        {
            _statusRepository = statusRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<StatusResponse> DeleteAsync(int id)
        {
            var existingTag = await _statusRepository.FindById(id);

            if (existingTag == null)
                return new StatusResponse("Status not found");

            try
            {
                _statusRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();
                return new StatusResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new StatusResponse($"An error ocurred while deleting status: {ex.Message}");
            }
        }

        public async Task<StatusResponse> GetByIdAsync(int id)
        {
            var existingTag = await _statusRepository.FindById(id);

            if (existingTag == null)
                return new StatusResponse("Status not found");
            return new StatusResponse(existingTag);
        }
        
        public async Task<StatusResponse> SaveAsync(Status city)
        {
            try
            {
                await _statusRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new StatusResponse(city);
            }
            catch (Exception e)
            {
                return new StatusResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<Status>> ListAsync()
        {
            return await _statusRepository.ListAsync();

        }

        public async Task<StatusResponse> UpdateAsync(int id, Status city)
        {
            var existingCity = await _statusRepository.FindById(id);

            if (existingCity == null)
                return new StatusResponse("Status not found");

            existingCity.NStatus = city.NStatus;

            try
            {
                _statusRepository.Update(existingCity);

                return new StatusResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new StatusResponse($"An error ocurred while updating the status: {ex.Message}");
            }

        }
    }
}