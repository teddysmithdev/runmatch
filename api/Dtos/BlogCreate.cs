using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class BlogCreate
    {
        public int BlogId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MinLength(30, ErrorMessage = "Must be at least 30 characters")]
        [MaxLength(100, ErrorMessage = "Must be less that 100 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MinLength(500, ErrorMessage = "Must be at least 500 characters")]
        [MaxLength(10000, ErrorMessage = "Must be less that 10000 characters")]
        public string Content { get; set; }
        public int? PhotoId { get; set; }

    }
}