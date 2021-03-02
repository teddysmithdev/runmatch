using System;
using api.Dtos;

namespace api.Entities
{
    public class BlogComment
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}