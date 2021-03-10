using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;

namespace api.Interfaces
{
    public interface IClubCommentRepository
    {
        Task<bool> CreateAsync(ClubComment clubComment);
        Task<ClubComment> UpdateAsync(ClubComment clubComment, int applicationUserId);
        Task<List<ClubComment>> GetAllAsync(int commentId);
        Task<ClubComment> GetAsync(int commentId);
        Task<int> DeleteAsync(int commentId);
    }
}