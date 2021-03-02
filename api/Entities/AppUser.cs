using System;
using System.Collections.Generic;
using api.Entities;
using API.Domain;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pace { get; set; }
        public int Mileage { get; set; }
        public string RunTime { get; set; }
        public ICollection<Club> Club { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<UserInvite> InvitedByUsers { get; set; }
        public ICollection<UserInvite> InvitedUsers { get; set; }
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesRecieved { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}