using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IInviteRepository
    {
        Task<UserInvite> GetUserInvite(int sourceUserId, int invitedUserId);
        Task<AppUser> GetUserWithInvites(int userId);
        Task<PagedList<InviteDto>> GetUserInvites(InviteParams inviteParams);
    }
}