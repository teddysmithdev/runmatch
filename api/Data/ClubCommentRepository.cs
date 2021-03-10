using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using api.Interfaces;
using API.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ClubCommentRepository : IClubCommentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ClubCommentRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<bool> CreateAsync(ClubComment clubComment)
        {
            var club = await _context.Clubs.FindAsync(clubComment.Id);

            if (club == null) return false;

            var user = await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == clubComment.UserName);

            var comment = new ClubComment
            {
                Author = user,
                Club = club,
                Body = clubComment.Body
            };

            club.Comments.Add(comment);

            var success = await _context.SaveChangesAsync() > 0;

            if (success) return true;

            return false;
        }

        public Task<int> DeleteAsync(int commentId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ClubComment>> GetAllAsync(int clubId)
        {
            var comments = await _context.ClubComments
                .Where(x => x.Club.Id == clubId)
                .OrderBy(x => x.CreatedAt)
                .ProjectTo<ClubComment>(_mapper.ConfigurationProvider)
                .ToListAsync();

                return comments;
        }

        public Task<ClubComment> GetAsync(int commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ClubComment> UpdateAsync(ClubComment clubComment, int applicationUserId)
        {
            throw new System.NotImplementedException();
        }
    }
}