using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;

namespace api.Interfaces
{
    public interface IBlogCommentRepository
    {
        Task<bool> CreateAsync(BlogCommentCreate blogComment);
        Task<BlogComment> UpdateAsync(BlogCommentCreate blogCommentCreate, int applicationUserId);
        Task<List<BlogComment>> GetAllAsync(int blogId);
        Task<BlogComment> GetAsync(int blogCommentId);
        Task<int> DeleteAsync(int blogCommentId);
    }
}