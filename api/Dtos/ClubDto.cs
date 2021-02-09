using System;
using API.Domain;

namespace API.Dtos.ClubDto
{
    public class ClubDto
    {
        public string Name { get; set; }
        public string Intro { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public CreateEventDto Events { get; set; }
    }
}