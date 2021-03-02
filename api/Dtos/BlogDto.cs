using System;
using System.Collections.Generic;
using api.Entities;
using API.Entities;

namespace api.Dtos
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<BlogComment> BlogComments { get; set; }
    }
}