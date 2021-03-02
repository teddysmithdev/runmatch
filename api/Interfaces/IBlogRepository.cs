using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Helpers;
using API.Helpers;

namespace api.Interfaces
{
    public interface IBlogRepository
    {
        Task<bool> CreateAsync(BlogCreate blogCreate);
        Task<bool> UpdateAsync(Blog blog, int applicationUserId);
        Task<PagedList<Blog>> GetAllAsync(BlogParams blogParams);
        Task<Blog> GetAsync(int blogId);
        Task<List<Blog>> GetAllByUserIdAsync(int applicationUserId);
        Task<List<Blog>> GetAllFamousAsync();
        Task<int> DeleteAsync(int blogId);
    }
}