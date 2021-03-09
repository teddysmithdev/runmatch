using System.Collections.Generic;
using System.Threading.Tasks;
using api.Entities;
using API.Controllers;
using API.Extenstions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class PhotoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public PhotoController(IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogPhoto>>> GetPhotoByUserId()
        {
            var userId = User.GetUserId();

            var photos = await _unitOfWork.PhotoRepository.GetAllBlogPhotosByUserIdAsync(userId);

            return Ok(photos);
        }
    }
}