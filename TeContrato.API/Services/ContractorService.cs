using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Services
{
    public class ContractorService : IContractorService
    {
        private readonly IContractorRepository _contractorRepository;
        public readonly IUnitOfWork _unitOfWork;


        public ContractorService(IContractorRepository contractorRepository, IUnitOfWork unitOfWork)
        {
            _contractorRepository = contractorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContractorResponse> DeleteAsync(int id)
        {
            var existingContractor = await _contractorRepository.FindById(id);

            if (existingContractor == null)
                return new ContractorResponse("City not found");

            try
            {
                _contractorRepository.Remove(existingContractor);
                await _unitOfWork.CompleteAsync();
                return new ContractorResponse(existingContractor);
            }
            catch (Exception ex)
            {
                return new ContractorResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<ContractorResponse> GetByIdAsync(int id)
        {
            var existingContractor = await _contractorRepository.FindById(id);

            if (existingContractor == null)
                return new ContractorResponse("City not found");
            return new ContractorResponse(existingContractor);
        }
        
        public async Task<ContractorResponse> SaveAsync(Contractor contractor)
        {
            try
            {
                await _contractorRepository.AddAsync(contractor);
                await _unitOfWork.CompleteAsync();

                return new ContractorResponse(contractor);
            }
            catch (Exception e)
            {
                return new ContractorResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<Contractor>> ListAsync()
        {
            return await _contractorRepository.ListAsync();

        }

        public async Task<ContractorResponse> UpdateAsync(int id, Contractor contractor)
        {
            var existingContractor = await _contractorRepository.FindById(id);

            if (existingContractor == null)
                return new ContractorResponse("City not found");

            existingContractor.Cuser = contractor.Cuser;

            try
            {
                _contractorRepository.Update(existingContractor);

                return new ContractorResponse(existingContractor);
            }
            catch (Exception ex)
            {
                return new ContractorResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}
