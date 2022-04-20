using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        public readonly IUnitOfWork _unitOfWork;
        
        public BudgetService(IBudgetRepository budgetRepository, IUnitOfWork unitOfWork)
        {
            _budgetRepository = budgetRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BudgetResponse> DeleteAsync(int id)
        {
            var existingTag = await _budgetRepository.FindById(id);

            if (existingTag == null)
                return new BudgetResponse("Budget not found");

            try
            {
                _budgetRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();
                return new BudgetResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new BudgetResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<BudgetResponse> GetByIdAsync(int id)
        {
            var existingTag = await _budgetRepository.FindById(id);

            if (existingTag == null)
                return new BudgetResponse("Budget not found");
            return new BudgetResponse(existingTag);
        }
        
        public async Task<BudgetResponse> SaveAsync(Budget city)
        {
            try
            {
                await _budgetRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new BudgetResponse(city);
            }
            catch (Exception e)
            {
                return new BudgetResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<Budget>> ListAsync()
        {
            return await _budgetRepository.ListAsync();

        }

        public async Task<BudgetResponse> UpdateAsync(int id, Budget city)
        {
            var existingCity = await _budgetRepository.FindById(id);

            if (existingCity == null)
                return new BudgetResponse("Budget not found");

            existingCity.TDescription = city.TDescription;
            existingCity.MMonto = city.MMonto;

            try
            {
                _budgetRepository.Update(existingCity);
                await _unitOfWork.CompleteAsync();

                return new BudgetResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new BudgetResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}