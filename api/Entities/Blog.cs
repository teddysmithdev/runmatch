using System;
using System.Collections.Generic;
using api.Dtos;
using API.Entities;

namespace api.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? PhotoId { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<BlogComment> BlogComments { get; set; }
    }
}