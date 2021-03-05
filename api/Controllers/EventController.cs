using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Helpers;
using API.Domain;
using API.Dtos;
using API.Extenstions;
using API.Helpers;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EventController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventController(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/events")]
        public async Task<ActionResult<PagedList<Event>>> GetEvents([FromQuery]EventParams eventParams)
        {
            var events = await _unitOfWork.EventRepository.GetAllEventsAsync(eventParams);
            var eventsToReturn = _mapper.Map<IEnumerable<Event>>(events);
            Response.AddPaginationHeader(events.CurrentPage, events.PageSize, events.TotalCount, events.TotalPages);
            return Ok(eventsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(int id)
        {
            var eventt = await _unitOfWork.EventRepository.GetEventByIdAsync(id);
            return eventt;
        }

        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] EventCreateDto eventCreate)
        {
            if (eventCreate == null)
            {
                return BadRequest();
            }

            var username = User.GetUsername();
            var user = await _unitOfWork.UserRepository.GetUserByUsername(username);

            var eventt = new Event 
            {
                Title = eventCreate.Title,
                Location = eventCreate.Location,
                City = eventCreate.City,
                State = eventCreate.State,
                Category = eventCreate.Category,
                Date = eventCreate.Date,
            };

            await _unitOfWork.EventRepository.CreateEventAsync(eventt);

            return Ok(eventt);
        }

        [HttpPost("{id}/attend")]
        public async Task<ActionResult> AddAttendee(int eventId)
        {
            var sourceUserId = User.GetUserId();
            var result = await _unitOfWork.EventRepository.AddAttendee(eventId, sourceUserId);

            if (result == false) return BadRequest("Failed to attend");
            
            return Ok();
        }
    }

}