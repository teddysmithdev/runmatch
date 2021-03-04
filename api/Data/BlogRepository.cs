using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using API.Data;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BlogRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateBlogAsync(BlogCreate blogCreate, int applicationUserId)
        {
            var blog = new Blog {
                Title = blogCreate.Title,
                Content = blogCreate.Content,
                AppUserId = applicationUserId
            };
            _context.Blogs.Add(blog);
            var created = await _context.SaveChangesAsync();
            return created > 0;

        }

        public async Task<bool> DeleteBlogAsync(int blogId)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(u => u.Id == blogId);

            _context.Blogs.Remove(blog);

            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<PagedList<Blog>> GetAllBlogsAsync(BlogParams blogParams)
        {
            var query =  _context.Blogs.AsQueryable();

            return await PagedList<Blog>.CreateAsync(query.ProjectTo<Blog>(_mapper.ConfigurationProvider)
                .AsNoTracking(), blogParams.PageNumber, blogParams.PageSize);
        }

        public async Task<List<Blog>> GetAllBlogsByUserIdAsync(BlogParams blogParams, int applicationUserId)
        {
            var query = _context.Blogs.Where(u => u.AppUserId == applicationUserId);

            return await PagedList<Blog>.CreateAsync(
                query.ProjectTo<Blog>(_mapper.ConfigurationProvider), blogParams.PageNumber, blogParams.PageSize);

        }

        public Task<List<Blog>> GetAllBlogsFamousAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Blog> GetBlogAsync(int blogId)
        {
            return _context.Blogs.FirstOrDefaultAsync(u => u.Id == blogId);
        }

        public async Task<bool> UpdateBlogAsync(BlogCreate blogCreate, int applicationUserId)
        {
            var blog = new Blog {
                AppUserId = applicationUserId,
                Title = blogCreate.Title,
                Content = blogCreate.Content,
                // PhotoId = blogCreate.PhotoId,
            };
            _context.Blogs.Update(blog);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
    }
}