using System;
using API.Entities;

namespace api.Entities
{
    public class ClubComment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string UserName { get; set; }
        public AppUser Author { get; set; }
        public Club Club { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    }
}