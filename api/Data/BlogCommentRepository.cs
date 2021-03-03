using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Interfaces;
using API.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class BlogCommentRepository : IBlogCommentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BlogCommentRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> CreateAsync(BlogCommentCreate blogComment)
        {
            var blogCommentToReturn = _mapper.Map<BlogComment>(blogComment);
            await _context.BlogComments.AddAsync(blogCommentToReturn);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public Task<int> DeleteAsync(int blogCommentId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<BlogComment>> GetAllAsync(int blogId)
        {
            return await _context.BlogComments.Include(u => u.Blog).Where(u => u.BlogId == blogId).ToListAsync();
        }

        public async Task<BlogComment> GetAsync(int blogCommentId)
        {
            return await _context.BlogComments.FirstOrDefaultAsync(u => u.Id == blogCommentId);
        }

        public Task<BlogComment> UpdateAsync(BlogCommentCreate blogCommentCreate, int applicationUserId)
        {
            throw new System.NotImplementedException();
        }
    }
}