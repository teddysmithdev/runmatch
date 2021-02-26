using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class BlogCommentCreate
    {
        public int BlogCommentId { get; set; }
        public int? ParentBlogCommentId { get; set; }
        public int BlogId { get; set; }
        [Required(ErrorMessage = "Content is required")]
        [MinLength(30, ErrorMessage = "Must be at least 30 characters")]
        [MaxLength(100, ErrorMessage = "Must be less that 100 characters")]
        public string Content { get; set; }
    }
}