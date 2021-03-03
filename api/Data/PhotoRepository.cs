using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Interfaces;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext _context;
        private readonly IPhotoService _photoService;
        public PhotoRepository(DataContext context, IPhotoService photoService)
        {
            _photoService = photoService;
            _context = context;
        }

        public async Task<bool> DeleteBlogPhotoAsync(int photoId)
        {
            var blogPhoto = await _context.BlogPhotos.FirstOrDefaultAsync(u => u.Id == photoId);

            _context.BlogPhotos.Remove(blogPhoto);

            await _photoService.DeletePhotoAsync(photoId.ToString());

            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;

        }

        public async Task<List<BlogPhoto>> GetAllBlogPhotosByUserIdAsync(int applicationUserId)
        {
            var userBlogPhotos = await _context.BlogPhotos
            .Include(u => u.AppUser)
            .Where(u => u.Id == applicationUserId)
            .ToListAsync();
            return userBlogPhotos;

        }
        public async Task<BlogPhoto> GetBlogPhotoAsync(int photoId)
        {
            return await _context.BlogPhotos.FirstOrDefaultAsync(u => u.Id == photoId);
        }
        public async Task<bool> InsertBlogPhotoAsync(PhotoCreate photoCreate, int applicationUserId)
        {
            await _context.BlogPhotos.AddAsync(new BlogPhoto {
                AppUserId = applicationUserId,
                ImageUrl = photoCreate.ImageUrl,
                PublicId = photoCreate.PublicId,
                Description = photoCreate.Description,
            });
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
    }
}