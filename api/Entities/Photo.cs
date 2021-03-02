using System;
using System.ComponentModel.DataAnnotations.Schema;
using api.Dtos;
using api.Entities;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool isMain { get; set; }
        public string Description { get; set; }
        public string PublicId { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}