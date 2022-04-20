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
    public class JobServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAllAsyncWhenNoJobsReturnsEmptyCollection()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIJobRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();

            mockCareerRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Job>());

            var service = new JobService(mockCareerRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Job> result = (List<Job>)await service.ListAsync();
            var careersCount = result.Count;

            //Assert
            careersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsJobsNotFoundResponse()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIJobRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var careerId = 1;
            Job career = new Job();
            mockCareerRepository.Setup(r => r.FindById(careerId)).Returns(Task.FromResult<Job>(null));

            var service = new JobService(mockCareerRepository.Object, mockUnitOfWork.Object);
            //Act
            JobResponse result = await service.GetByIdAsync(careerId);
            var message = result.Message;
            //Assert
            message.Should().Be("Career not found");
        }
        private Mock<IJobRepository> GetDefaultIJobRepositoryInstance()
        {
            return new Mock<IJobRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}