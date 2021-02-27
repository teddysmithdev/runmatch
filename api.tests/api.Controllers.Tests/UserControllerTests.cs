using System.Threading.Tasks;
using API.Controllers;
using API.Dtos;
using API.Helpers;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Moq;
using NUnit.Framework;

namespace api.tests.api.Controllers.Tests
{
    public class UserControllerTests
    {
        // [Test]
        // public void Should_Return_User_When_NotFound()
        // {
        //     var mockRepo = new Mock<IUnitOfWork>();
        //     var mockMapper = new Mock<IMapper>();
        //     var mockPhotoService = new Mock<PhotoService>();
        //     var userParms = new UserParams();
        //     var user = new PagedList<MemberDto>();
        //     mockRepo.Setup(r => r.UserRepository.GetMembersAsync(userParms)).Returns(Task.FromResult(user));

        //     var controller = new UserController(mockPhotoService.Object, mockMapper.Object, mockRepo.Object);

        //     var result = controller.GetUsers(userParms);

        //     Assert.Equal(user, result.Value);
        // }
    }
}