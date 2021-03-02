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
        public Task<int> DeleteAsync(int blogId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedList<Blog>> GetAllAsync(BlogParams blogParams)
        {
            var query =  _context.Blogs.AsQueryable();

            return await PagedList<Blog>.CreateAsync(query.ProjectTo<Blog>(_mapper.ConfigurationProvider)
                .AsNoTracking(), blogParams.PageNumber, blogParams.PageSize);
        }

        public async Task<List<Blog>> GetAllByUserIdAsync(int applicationUserId)
        {
            return await _context.Blogs.Include(u => u.AppUser).Where(u => u.AppUserId == applicationUserId).ToListAsync();
        }

        public Task<List<Blog>> GetAllFamousAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Blog> GetAsync(int blogId)
        {
            return  await _context.Blogs.FirstOrDefaultAsync(u => u.Id == blogId);
        }

        public async Task<bool> CreateAsync(BlogCreate blog)
        {
            var mapToBlog = _mapper.Map<Blog>(blog);
            await _context.Blogs.AddAsync(mapToBlog);
            var created = await _context.SaveChangesAsync();
            return created > 0;

        }

        public async Task<bool> UpdateAsync(Blog blog, int applicationUserId)
        {
            _context.Blogs.Update(blog);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
    }
}