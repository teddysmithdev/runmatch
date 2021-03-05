using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using api.Helpers;
using API.Data;
using API.Domain;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EventRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> CreateEventAsync(Event eventt)
        {
            await _context.Events.AddAsync(eventt);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var eventToReturn = await _context.Events.FirstOrDefaultAsync(u => u.Id == eventId);

            _context.Events.Remove(eventToReturn);

            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public Task<Event> GetEventByIdAsync(int eventId)
        {
            return _context.Events.FirstOrDefaultAsync(u => u.Id == eventId);
        }

        public async Task<PagedList<Event>> GetAllEventsAsync(EventParams eventParams)
        {
            var query = _context.Blogs.AsQueryable();

            return await PagedList<Event>.CreateAsync(query.ProjectTo<Event>(_mapper.ConfigurationProvider)
                .AsNoTracking(), eventParams.PageNumber, eventParams.PageSize);
        }

        public async Task<bool> UpdateEventAsync(Event eventToUpdate)
        {
            _context.Events.Update(eventToUpdate);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> AddAttendee(int eventId, int sourceUserId)
        {
            var eventt = await _context.Events
            .Include(u => u.Attendees)
            .ThenInclude(u => u.AppUser)
            .SingleOrDefaultAsync(x => x.Id == eventId);

            if (eventt == null) return false;

            var user = _context.Users.FirstOrDefault(u => u.Id == sourceUserId);

            if (user == null) return false;

            var hostUsername = eventt.Attendees.FirstOrDefault(x => x.IsHost)?.AppUser?.UserName;

            var attendance = eventt.Attendees.FirstOrDefault(x => x.AppUser.UserName == user.UserName);

            if (attendance != null && hostUsername == user.UserName)
                eventt.IsCancelled = !eventt.IsCancelled;
            
            if (attendance != null && hostUsername != user.UserName)
                eventt.Attendees.Remove(attendance);

            if (attendance == null)
            {
                attendance = new EventAttendee
                {
                    AppUser = user,
                    Event = eventt,
                    IsHost = false
                };

                eventt.Attendees.Add(attendance);
            }

            var result = await _context.SaveChangesAsync() > 0;

            return result;
        }
    }
}