using System;
using System.Collections.Generic;
using API.Entities;

namespace API.Dtos.ClubDto
{
    public class ClubDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}