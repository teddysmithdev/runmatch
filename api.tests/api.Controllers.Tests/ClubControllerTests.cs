using System.Threading.Tasks;
using api.Helpers;
using API.Controllers;
using API.Domain;
using API.Dtos;
using API.Dtos.ClubDto;
using API.Helpers;
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
        public void GetReturnsClubs()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();
            var clubParams = new ClubParams();
            var controller = new ClubController(mapper.Object, mockRepo.Object);
            
            //Act
            var result = controller.GetClubs(clubParams);

            //Assert
            Assert.IsAssignableFrom<Task<ActionResult<PagedList<ClubDto>>>>(result);
        }

        [Test]
        public void GetReturnsClub()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();
            var controller = new ClubController(mapper.Object, mockRepo.Object);
            var clubId = 1;
            
            //Act
            var result = controller.GetClub(clubId);

            //Assert
            Assert.IsAssignableFrom<Task<IActionResult>>(result);
        }

        [Test]
        public void CreateReturnsClub()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();
            var controller = new ClubController(mapper.Object, mockRepo.Object);
            var createClubDto = new CreateClubDto();
            
            //Act
            var result = controller.Create(createClubDto);

            //Assert
            Assert.IsAssignableFrom<Task<IActionResult>>(result);
        }

        [Test]
        public void PutReturnsActionResult()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();
            var controller = new ClubController(mapper.Object, mockRepo.Object);
            var createClubDto = new CreateClubDto();
            var club = new Club();
            var clubId = 1;
            
            //Act
            var result = controller.Update(clubId, club);

            //Assert
            Assert.IsAssignableFrom<Task<IActionResult>>(result);
        }

        [Test]
        public void DeleteReturnsActionResult()
        {
            //Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();
            var controller = new ClubController(mapper.Object, mockRepo.Object);
            var createClubDto = new CreateClubDto();
            var club = new Club();
            var clubId = 1;
            
            //Act
            var result = controller.Delete(clubId);

            //Assert
            Assert.IsAssignableFrom<Task<IActionResult>>(result);
        }
        
        
    }
}