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
    public class ProjectServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAllAsyncWhenNoProjectsReturnsEmptyCollection()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIProjectRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();

            mockCareerRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Project>());

            var service = new ProjectService(mockCareerRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Project> result = (List<Project>)await service.ListAsync();
            var careersCount = result.Count;

            //Assert
            careersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsProjectNotFoundResponse()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIProjectRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var careerId = 1;
            Project career = new Project();
            mockCareerRepository.Setup(r => r.FindById(careerId)).Returns(Task.FromResult<Project>(null));

            var service = new ProjectService(mockCareerRepository.Object, mockUnitOfWork.Object);
            //Act
            ProjectResponse result = await service.GetByIdAsync(careerId);
            var message = result.Message;
            //Assert
            message.Should().Be("Career not found");
        }
        private Mock<IProjectRepository> GetDefaultIProjectRepositoryInstance()
        {
            return new Mock<IProjectRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}