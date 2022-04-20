using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Services
{
    public class ControlEmployeesService : IControlEmployeesService
        {
            private readonly IControlEmployeesRepository _controlemployeeRepository;
            private readonly IUnitOfWork _unitOfWork;

            public ControlEmployeesService(IControlEmployeesRepository productTagRepository, IUnitOfWork unitOfWork)
            {
                _controlemployeeRepository = productTagRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<ControlEmployees>> ListAsync()
            {
                return await _controlemployeeRepository.ListAsync();
            }

            public async Task<IEnumerable<ControlEmployees>> ListByControlIdAsync(int controlId)
            {
                return await _controlemployeeRepository.ListByControlIdAsync(controlId);
            }

            public async Task<IEnumerable<ControlEmployees>> ListByEmployeeIdAsync(int employeeId)
            {
                return await _controlemployeeRepository.ListByEmployeeIdAsync(employeeId);
            }

            public async Task<ControlEmployeesResponse> AssignControlEmployeeAsync(int controlId, int employeeId)
            {
                try
                {
                    await _controlemployeeRepository.AssignControlEmployee(controlId, employeeId);
                    await _unitOfWork.CompleteAsync();
                    ControlEmployees controlEmployee = await _controlemployeeRepository.FindByControlIdAndEmployeeId(controlId, employeeId);
                    return new ControlEmployeesResponse(controlEmployee);

                }
                catch (Exception ex)
                {
                    return new ControlEmployeesResponse($"An error ocurred while assigning Control to Employee: {ex.Message}");
                }
            }

            public async Task<ControlEmployeesResponse> UnassignControlEmployeeAsync(int controlId, int employeeId)
            {
                try
                {
                    ControlEmployees productTag = await _controlemployeeRepository.FindByControlIdAndEmployeeId(controlId, employeeId);

                    _controlemployeeRepository.Remove(productTag);
                    await _unitOfWork.CompleteAsync();

                    return new ControlEmployeesResponse(productTag);

                }
                catch (Exception ex)
                {
                    return new ControlEmployeesResponse($"An error ocurred while unassigning Control to Employee: {ex.Message}");
                }

            }
        }
    }
