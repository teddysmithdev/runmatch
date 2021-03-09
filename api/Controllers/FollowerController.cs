using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Helpers;
using API.Controllers;
using API.Extenstions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class FollowerController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("{username}")]
        public async Task<ActionResult> AddFollow(string username)
        {
            var sourceUserId = User.GetUserId();
            var targetUser = await _unitOfWork.UserRepository.GetUserByUsername(username);
            var observerUser = await _unitOfWork.FollowRepository.GetUserWithFollowers(sourceUserId);

            if (targetUser == null) return NotFound();

            if (observerUser.UserName == username) return BadRequest("You cannot follow yourself");

            var userFollow = await _unitOfWork.FollowRepository.GetUserFollower(sourceUserId, targetUser.Id);

            if (userFollow != null) return BadRequest("You already are following this user");

            userFollow = new UserFollowing
            {
                ObserverId = sourceUserId,
                TargetId = targetUser.Id
            };

            observerUser.Followings.Add(userFollow);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to follow user");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FollowerDto>>> GetUserFollows([FromQuery]FollowerParams followerParams)
        {
            followerParams.UserId = User.GetUserId();
            var users = await _unitOfWork.FollowRepository.GetUserFollowers(followerParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }
    }
}