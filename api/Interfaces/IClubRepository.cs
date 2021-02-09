using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain;

namespace API.Interfaces
{
    public interface IClubRepository
    {
        Task<List<Club>> GetClubsAsync();
        Task<Club> GetClubByIdAsync(int clubId);
        Task<bool> CreateClubAsync(Club club);
        Task<bool> UpdateClubAsync(Club clubToUpdate);
        Task<bool> DeleteClubAsync(int clubId);
    }
}