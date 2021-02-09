using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Extenstions;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class InviteRepository : IInviteRepository
    {
        private readonly DataContext _context;
        public InviteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<UserInvite> GetUserInvite(int sourceUserId, int invitedUserId)
        {
            return await _context.Invites.FindAsync(sourceUserId, invitedUserId);

        }

        public async Task<PagedList<InviteDto>> GetUserInvites(InviteParams inviteParams)
        {
            var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
            var invites = _context.Invites.AsQueryable();

            if (inviteParams.Predicate == "invited")
            {
                invites = invites.Where(invite => invite.SourceUserId == inviteParams.UserId);
                users = invites.Select(invite => invite.InvitedUser);
            }

            if (inviteParams.Predicate == "invitedBy")
            {
                invites = invites.Where(invite => invite.InvitedUserId == inviteParams.UserId);
                users = invites.Select(invite => invite.SourceUser);
            }

            var invitedUsers = users.Select(user => new InviteDto {
                Username = user.UserName,
                Age = user.DateOfBirth.CalculateAge(),
                PhotoUrl = user.Photos.FirstOrDefault(p => p.isMain).Url,
                City = user.City,
                Id = user.Id
            });

            return await PagedList<InviteDto>.CreateAsync(invitedUsers, inviteParams.PageNumber, inviteParams.PageSize);

        }


        public async Task<AppUser> GetUserWithInvites(int userId)
        {
            return await _context.Users.Include(i => i.InvitedUsers).FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}