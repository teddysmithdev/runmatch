using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using API.Data;
using API.Entities;
using API.Extenstions;
using API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class FollowerRepository : IFollowRepository
    {
        private readonly DataContext _context;

        public FollowerRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<UserFollowing> GetUserFollower(int observerId, int targetId)
        {
            return await _context.UserFollowings.FindAsync(observerId, targetId);
        }

        public async Task<PagedList<FollowerDto>> GetUserFollowers(FollowerParams followerParams)
        {
            var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
            var followers = _context.UserFollowings.AsQueryable();

            if (followerParams.Predicate == "followed")
            {
                followers = followers.Where(follow => follow.ObserverId == followerParams.UserId);
                users = followers.Select(follow => follow.Observer);
            }

            if (followerParams.Predicate == "followedBy")
            {
                followers = followers.Where(follow => follow.TargetId == followerParams.UserId);
                users = followers.Select(follow => follow.Target);
            }

            var followedUsers = users.Select(user => new FollowerDto {
                Username = user.UserName,
                Age = user.DateOfBirth.CalculateAge(),
                PhotoUrl = user.Photos.FirstOrDefault(p => p.isMain).Url,
                City = user.City,
                Id = user.Id
            });

            return await PagedList<FollowerDto>.CreateAsync(followedUsers, followerParams.PageNumber, followerParams.PageSize);
        }

        public async Task<AppUser> GetUserWithFollowers(int userId)
        {
            return await _context.Users.Include(i => i.Followings).FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}