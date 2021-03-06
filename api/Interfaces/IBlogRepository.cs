using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Helpers;
using API.Entities;
using API.Helpers;

namespace api.Interfaces
{
    public interface IBlogRepository
    {
        Task<bool> CreateBlogAsync(BlogCreate blogCreate, AppUser user);
        Task<bool> UpdateBlogAsync(BlogCreate blogCreate, int applicationUserId);
        Task<PagedList<Blog>> GetAllBlogsAsync(BlogParams blogParams);
        Task<Blog> GetBlogAsync(int blogId);
        Task<List<Blog>> GetAllBlogsByUsernameAsync(BlogParams blogParams, string username);
        Task<List<Blog>> GetAllBlogsFamousAsync();
        Task<bool> DeleteBlogAsync(int blogId);
    }
}