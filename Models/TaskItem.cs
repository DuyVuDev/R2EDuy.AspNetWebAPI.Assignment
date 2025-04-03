using System.ComponentModel.DataAnnotations;

namespace R2EDuy.AspNetWebAPI.Assignment.Models
{
    public class TaskItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Title cannot be empty!")]
        public required string Title { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
