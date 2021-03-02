using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Interfaces;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class BlogCommentRepository : IBlogCommentRepository
    {
        private readonly DataContext _context;

        public BlogCommentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(BlogComment blogComment)
        {
            await _context.BlogComments.AddAsync(blogComment);
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