using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Domain;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ClubRepository : IClubRepository
    {
        private readonly DataContext _context;

        public ClubRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateClubAsync(Club club)
        {
            await _context.Clubs.AddAsync(club);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteClubAsync(int clubId)
        {
            var club = await GetClubByIdAsync(clubId);

            _context.Clubs.Remove(club);

            var deleted = await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Club> GetClubByIdAsync(int clubId)
        {
            return await _context.Clubs.SingleOrDefaultAsync(x => x.Id == clubId);
        }

        public async Task<List<Club>> GetClubsAsync()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<bool> UpdateClubAsync(Club clubToUpdate)
        {
            _context.Clubs.Update(clubToUpdate);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
    }
}