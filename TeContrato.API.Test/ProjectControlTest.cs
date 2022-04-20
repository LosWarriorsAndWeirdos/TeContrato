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
    public class ProjectControlTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAllAsyncWhenNoProjectControlsReturnsEmptyCollection()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIProjectControlRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();

            mockCareerRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<ProjectControl>());

            var service = new ProjectControlService(mockCareerRepository.Object, mockUnitOfWork.Object);

            //Act
            List<ProjectControl> result = (List<ProjectControl>)await service.ListAsync();
            var careersCount = result.Count;

            //Assert
            careersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsProjectControlsNotFoundResponse()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIProjectControlRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var careerId = 1;
            ProjectControl career = new ProjectControl();
            mockCareerRepository.Setup(r => r.FindById(careerId)).Returns(Task.FromResult<ProjectControl>(null));

            var service = new ProjectControlService(mockCareerRepository.Object, mockUnitOfWork.Object);
            //Act
            ProjectControlResponse result = await service.GetByIdAsync(careerId);
            var message = result.Message;
            //Assert
            message.Should().Be("Career not found");
        }
        private Mock<IProjectControlRepository> GetDefaultIProjectControlRepositoryInstance()
        {
            return new Mock<IProjectControlRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}