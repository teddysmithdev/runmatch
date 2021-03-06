using System;
using System.Collections.Generic;
using API.Entities;

namespace api.Dtos
{
    public class EventDto
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public ICollection<EventAttendee> Attendees { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}