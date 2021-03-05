using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Helpers;
using API.Domain;
using API.Helpers;

namespace API.Interfaces
{
    public interface IEventRepository
    {
        Task<PagedList<Event>> GetAllEventsAsync(EventParams eventParams);
        Task<Event> GetEventByIdAsync(int eventId);
        Task<bool> CreateEventAsync(Event eventt);
        Task<bool> UpdateEventAsync(Event eventToUpdate);
        Task<bool> DeleteEventAsync(int eventId);
        Task<bool> AddAttendee(int eventId, int sourceUserId);
    }
}