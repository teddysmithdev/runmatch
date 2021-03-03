using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos;
using api.Entities;
using API.Controllers;
using API.Extenstions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class BlogCommentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BlogCommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("")]
        public async Task<ActionResult<BlogComment>> Create(BlogCommentCreate blogCommentCreate)
        {
            var userId = await _unitOfWork.UserRepository.GetUserByUsername(User.GetUsername());
            var createdBlogComment = await _unitOfWork.BlogCommentRepository.CreateAsync(blogCommentCreate);
            return Ok(createdBlogComment);
        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult<List<BlogComment>>> GetAll(int blogId)
        {
            var blogComments = await _unitOfWork.BlogCommentRepository.GetAllAsync(blogId);

            return blogComments;
        }
    }
}