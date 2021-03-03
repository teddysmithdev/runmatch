using System;
using API.Entities;

namespace api.Entities
{
    public class BlogPhoto
    {
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}