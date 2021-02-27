using System;
using api.Dtos;

namespace api.Entities
{
    public class BlogComment
    {
        public string Username { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}