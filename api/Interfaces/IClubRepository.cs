using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Helpers;
using API.Dtos.ClubDto;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IClubRepository
    {
        Task<PagedList<ClubDto>> GetClubsAsync(ClubParams clubParams);
        Task<Club> GetClubByIdAsync(int clubId);
        Task<bool> CreateClubAsync(Club club);
        Task<bool> UpdateClubAsync(Club clubToUpdate);
        Task<bool> DeleteClubAsync(int clubId);
    }
}