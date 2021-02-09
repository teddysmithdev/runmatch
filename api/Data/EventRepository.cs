using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Domain;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateEventAsync(Event eventt)
        {
            await _context.Events.AddAsync(eventt);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public Task<bool> DeleteEventAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetEventByIdAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public Task<bool> UpdateEventAsync(Event eventToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}