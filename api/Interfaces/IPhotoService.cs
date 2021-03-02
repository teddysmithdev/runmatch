using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using API.Entities;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace API.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
        Task<Photo> GetAsync(int photoId);
        Task<List<Photo>> GetAllByUserIdAsync(PhotoCreate photoCreate, int applicationUserId);
    }
}