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
    public class CityServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAllAsyncWhenNoCitiesReturnsEmptyCollection()
        {
            //Arrange
            var mockCityRepository = GetDefaultICityRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();

            mockCityRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<City>());

            var service = new CityService(mockCityRepository.Object, mockUnitOfWork.Object);

            //Act
            List<City> result = (List<City>)await service.ListAsync();
            var careersCount = result.Count;

            //Assert
            careersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsCareersNotFoundResponse()
        {
            //Arrange
            var mockCareerRepository = GetDefaultICityRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var careerId = 1;
            City career = new City();
            mockCareerRepository.Setup(r => r.FindById(careerId)).Returns(Task.FromResult<City>(null));

            var service = new CityService(mockCareerRepository.Object, mockUnitOfWork.Object);
            //Act
            CityResponse result = await service.GetByIdAsync(careerId);
            var message = result.Message;
            //Assert
            message.Should().Be("Career not found");
        }
        private Mock<ICityRepository> GetDefaultICityRepositoryInstance()
        {
            return new Mock<ICityRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}