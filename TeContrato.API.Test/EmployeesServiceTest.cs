using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Persistence.Repositories;
using TeContrato.API.Domain.Services.Communications;
using TeContrato.API.Services;

namespace TeContrato.API.Test
{
    public class EmployeesServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAllAsyncWhenNoCareersReturnsEmptyCollection()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIEmployeesRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();

            mockCareerRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Employees>());

            var service = new EmployeesService(mockCareerRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Employees> result = (List<Employees>)await service.ListAsync();
            var careersCount = result.Count;

            //Assert
            careersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsCareersNotFoundResponse()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIEmployeesRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var careerId = 1;
            Employees career = new Employees();
            mockCareerRepository.Setup(r => r.FindById(careerId)).Returns(Task.FromResult<Employees>(null));

            var service = new EmployeesService(mockCareerRepository.Object, mockUnitOfWork.Object);
            //Act
            EmployeesResponse result = await service.GetByIdAsync(careerId);
            var message = result.Message;
            //Assert
            message.Should().Be("Career not found");
        }
        private Mock<IEmployeeRepository> GetDefaultIEmployeesRepositoryInstance()
        {
            return new Mock<IEmployeeRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}