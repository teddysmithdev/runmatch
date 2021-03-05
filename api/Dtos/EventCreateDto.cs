using System;

namespace api.Dtos
{
    public class EventCreateDto
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }
}