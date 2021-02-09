using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain;

namespace API.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> GetEventsAsync();
        Task<Event> GetEventByIdAsync(int eventId);
        Task<bool> CreateEventAsync(Event eventt);
        Task<bool> UpdateEventAsync(Event eventToUpdate);
        Task<bool> DeleteEventAsync(int eventId);
    }
}