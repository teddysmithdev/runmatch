using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using api.Helpers;
using API.Controllers;
using API.Entities;
using API.Extenstions;
using API.Helpers;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class BlogController : BaseApiController
    {
        private readonly PhotoService _photoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogController(PhotoService photoService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _photoService = photoService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/blogs")]
        public async Task<ActionResult<PagedList<BlogDto>>> GetBlogs([FromQuery] BlogParams blogParams)
        {
            var blogs = await _unitOfWork.BlogRepository.GetAllAsync(blogParams);
            var blogsToReturn = _mapper.Map<IEnumerable<BlogDto>>(blogs);
            Response.AddPaginationHeader(blogs.CurrentPage, blogs.PageSize, blogs.TotalCount, blogs.TotalPages);
            return Ok(blogsToReturn);
        }

        [HttpGet("api/blogs/{id}")]
        public async Task<ActionResult<Blog>> Get(int id)
        {
            var blog = await _unitOfWork.BlogRepository.GetAsync(id);
            return blog;
        }

        [HttpGet("api/blogs/user/{userId}")]
        public async Task<ActionResult<List<Blog>>> GetByApplicationUserId(int userId)
        {
            var blogs = await _unitOfWork.BlogRepository.GetAllByUserIdAsync(userId);
            return blogs;
        }

        [HttpPost("api/blogs")]
        public async Task<ActionResult<Blog>> Create(BlogCreate blogCreate)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsername(User.GetUsername());

            if (blogCreate.PhotoId.HasValue)
            {
                var photo = await _photoService.GetAsync(blogCreate.PhotoId.Value);

                if (photo.AppUserId != user.Id)
                {
                    return BadRequest("You did not upload the photo.");
                }
            }

            var blog = await _unitOfWork.BlogRepository.CreateAsync(blogCreate);

            return Ok(blog);
        }

        [HttpPost("api/blogs/photo-upload")]
        public async Task<ActionResult<Photo>> UploadPhoto(IFormFile file)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsername(User.GetUsername());

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var photoCreate = new Photo
            {
                PublicId = result.PublicId,
                Url = result.SecureUrl.AbsoluteUri,
                Description = file.FileName
            };

            user.Photos.Add(photoCreate);

            return Ok();
        }
    }
}