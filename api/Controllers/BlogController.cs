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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public BlogController(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("")]
        public async Task<ActionResult<PagedList<BlogDto>>> GetBlogs([FromQuery] BlogParams blogParams)
        {
            var blogs = await _unitOfWork.BlogRepository.GetAllBlogsAsync(blogParams);
            var blogsToReturn = _mapper.Map<IEnumerable<BlogDto>>(blogs);
            Response.AddPaginationHeader(blogs.CurrentPage, blogs.PageSize, blogs.TotalCount, blogs.TotalPages);
            return Ok(blogsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> Get(int id)
        {
            var blog = await _unitOfWork.BlogRepository.GetBlogAsync(id);
            return blog;
        }

        [HttpGet("user/{username}")]
        public async Task<ActionResult<List<Blog>>> GetAllBlogsByUsername(BlogParams blogParams, string username)
        {
            var blogs = await _unitOfWork.BlogRepository.GetAllBlogsByUsernameAsync(blogParams, username);
            return blogs;
        }

        [HttpPost("")]
        public async Task<ActionResult<Blog>> Create(BlogCreate blogCreate)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsername(User.GetUsername());

            if (blogCreate.PhotoId.HasValue)
            {
                var photo = await _unitOfWork.PhotoRepository.GetBlogPhotoAsync(blogCreate.PhotoId.Value);

                if (photo.AppUserId != user.Id)
                {
                    return BadRequest("You did not upload the photo.");
                }
            }

            var blog = await _unitOfWork.BlogRepository.CreateBlogAsync(blogCreate, user.Id);

            return Ok(blog);
        }

        [HttpPost("/photo-upload")]
        public async Task<ActionResult<Photo>> UploadPhoto(IFormFile file)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsername(User.GetUsername());

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var photoCreate = new PhotoCreate
            {
                PublicId = result.PublicId,
                ImageUrl = result.SecureUrl.AbsoluteUri,
                Description = file.FileName
            };

            var photoInsert = _unitOfWork.PhotoRepository.InsertBlogPhotoAsync(photoCreate, user.Id);

            return Ok();
        }
    }
}