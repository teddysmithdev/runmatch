using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using API.Entities;

namespace api.Interfaces
{
    public interface IPhotoRepository
    {
        Task<bool> InsertBlogPhotoAsync(PhotoCreate photoCreate, int applicationUserId);
        Task<List<BlogPhoto>> GetAllBlogPhotosByUserIdAsync(int applicationUserId);
        Task<BlogPhoto> GetBlogPhotoAsync(int photoId);
        Task<bool> DeleteBlogPhotoAsync(int photoId);
    }
}