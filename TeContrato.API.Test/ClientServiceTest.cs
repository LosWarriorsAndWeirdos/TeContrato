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
    public class ClientServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAllAsyncWhenNoCareersReturnsEmptyCollection()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIClientRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();

            mockCareerRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Client>());

            var service = new ClientService(mockCareerRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Client> result = (List<Client>)await service.ListAsync();
            var careersCount = result.Count;

            //Assert
            careersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsCareersNotFoundResponse()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIClientRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var careerId = 1;
            Client career = new Client();
            mockCareerRepository.Setup(r => r.FindById(careerId)).Returns(Task.FromResult<Client>(null));

            var service = new ClientService(mockCareerRepository.Object, mockUnitOfWork.Object);
            //Act
            ClientResponse result = await service.GetByIdAsync(careerId);
            var message = result.Message;
            //Assert
            message.Should().Be("Career not found");
        }
        private Mock<IClientRepository> GetDefaultIClientRepositoryInstance()
        {
            return new Mock<IClientRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}