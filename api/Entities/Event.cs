using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Entities;
using API.Entities;

namespace API.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Category { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime Date { get; set; }
        public ICollection<EventAttendee> Attendees { get; set; }
        public int? ClubId { get; set; }
        public Club Club { get; set; }
    }
}