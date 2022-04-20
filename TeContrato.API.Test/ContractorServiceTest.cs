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
    public class ContractorServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAllAsyncWhenNoCareersReturnsEmptyCollection()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIContractorRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();

            mockCareerRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Contractor>());

            var service = new ContractorService(mockCareerRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Contractor> result = (List<Contractor>)await service.ListAsync();
            var careersCount = result.Count;

            //Assert
            careersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsCareersNotFoundResponse()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIContractorRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var careerId = 1;
            Contractor career = new Contractor();
            mockCareerRepository.Setup(r => r.FindById(careerId)).Returns(Task.FromResult<Contractor>(null));

            var service = new ContractorService(mockCareerRepository.Object, mockUnitOfWork.Object);
            //Act
            ContractorResponse result = await service.GetByIdAsync(careerId);
            var message = result.Message;
            //Assert
            message.Should().Be("Career not found");
        }
        private Mock<IContractorRepository> GetDefaultIContractorRepositoryInstance()
        {
            return new Mock<IContractorRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}