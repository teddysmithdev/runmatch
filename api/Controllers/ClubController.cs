using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using API.Dtos;
using API.Extenstions;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClubController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClubController(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/clubs")]
        public async Task<IActionResult> GetClubs()
        {
            return Ok( await _unitOfWork.ClubRepository.GetClubsAsync());
        }

        [HttpGet("api/clubs/{clubId}")]
        public async Task<IActionResult> GetClub([FromRoute] int clubId)
        {
            var club = await _unitOfWork.ClubRepository.GetClubByIdAsync(clubId);

            if (club == null)
                return NotFound();

            return Ok(club);
        }

        [HttpPost("api/clubs")]
        public async Task<IActionResult> Create([FromBody] CreateClubDto clubRequest)
        {
            if (clubRequest == null)
            {
                return BadRequest();
            }

            var username = User.GetUsername();
            var user = await _unitOfWork.UserRepository.GetUserByUsername(username);

            
            var club = new Club 
            { 
                Name = clubRequest.Name,
                City = clubRequest.City,
                State = clubRequest.State,
                Intro = clubRequest.Intro,
                AppUser = user,
                AppUserID = user.Id,
                Events = 
                new List<Event>
            {
                new Event {
                    Title = clubRequest.Events.Title,
                    Location = clubRequest.Events.Location,
                    Date = clubRequest.Events.Date, 
                    }
                }
            };

            
            await _unitOfWork.ClubRepository.CreateClubAsync(club);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/api/club/" + club.Name;

            var response = new Club { Name = club.Name };
            return Created(locationUri, response);
        }

        [HttpPut("api/clubs/{clubId}")]
        public async Task<IActionResult> Update([FromRoute]int clubId, [FromBody] Club request)
        {
            var club = new Club
            {
                Id = clubId,
                Name = request.Name
            };

            var updated = await _unitOfWork.ClubRepository.UpdateClubAsync(club);

            if(updated)
                return Ok();
            
            return NotFound();
        }

        [HttpDelete("api/clubs/{clubId}")]
        public async Task<IActionResult> Delete([FromRoute]int clubId)
        {
            var deleted = await _unitOfWork.ClubRepository.DeleteClubAsync(clubId);

            if(deleted)
                return NoContent();
            
            return NotFound();
        }
    }
}