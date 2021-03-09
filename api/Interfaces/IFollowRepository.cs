using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Helpers;
using API.Entities;
using API.Helpers;

namespace api.Interfaces
{
    public interface IFollowRepository
    {
        Task<UserFollowing> GetUserFollower(int observerId, int targetId);
        Task<AppUser> GetUserWithFollowers(int userId);
        Task<PagedList<FollowerDto>> GetUserFollowers(FollowerParams followerParams);
    }
}