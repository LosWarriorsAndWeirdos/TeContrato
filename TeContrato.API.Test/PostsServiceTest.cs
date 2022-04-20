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
    public class PostsServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAllAsyncWhenNoPostsReturnsEmptyCollection()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIPostsRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();

            mockCareerRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Posts>());

            var service = new PostsService(mockCareerRepository.Object, mockUnitOfWork.Object);

            //Act
            List<Posts> result = (List<Posts>)await service.ListAsync();
            var careersCount = result.Count;

            //Assert
            careersCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsyncWhenInvalidIdReturnsPostsNotFoundResponse()
        {
            //Arrange
            var mockCareerRepository = GetDefaultIPostsRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstace();
            var careerId = 1;
            Posts career = new Posts();
            mockCareerRepository.Setup(r => r.FindById(careerId)).Returns(Task.FromResult<Posts>(null));

            var service = new PostsService(mockCareerRepository.Object, mockUnitOfWork.Object);
            //Act
            PostsResponse result = await service.GetByIdAsync(careerId);
            var message = result.Message;
            //Assert
            message.Should().Be("Career not found");
        }
        private Mock<IPostRepository> GetDefaultIPostsRepositoryInstance()
        {
            return new Mock<IPostRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstace()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}