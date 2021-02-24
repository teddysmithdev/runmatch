using System.Threading.Tasks;
using API.Controllers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace api.tests.api.Controllers.Tests
{
    [TestFixture]
    public class ClubControllerTests
    {
        [Test]
        public async Task GetReturnsClubs()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();
            var controller = new ClubController(mapper.Object, mockRepo.Object);
            
            //Act
            var result = await controller.GetClubs();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Task<IActionResult>>(result);
        }
        
    }
}