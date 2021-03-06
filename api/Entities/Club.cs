using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities;

namespace API.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public int AppUserID {get; set;}
        public AppUser AppUser {get; set;}
        public ICollection<Event> Events {get; set;}
    }
}