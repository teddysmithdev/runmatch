using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using API.Data;
using API.Domain;
using API.Dtos.ClubDto;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ClubRepository : IClubRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClubRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<PagedList<ClubDto>> GetClubsAsync(ClubParams clubParams)
        {
            var query = _context.Clubs.AsQueryable();
            
            query = query.Where(u => u.City == clubParams.City);
            query = query.Where(u => u.State == clubParams.State);

            return await PagedList<ClubDto>.CreateAsync(query.ProjectTo<ClubDto>(_mapper.ConfigurationProvider)
                .AsNoTracking(), clubParams.PageNumber, clubParams.PageSize);
        
        }

        public async Task<bool> UpdateClubAsync(Club clubToUpdate)
        {
            _context.Clubs.Update(clubToUpdate);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
    }
}