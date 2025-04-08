using System.ComponentModel.DataAnnotations;

namespace R2EDuy.AspNetWebAPI.Assignment.Models
{
    public class TaskItemRequestUpdate
    {
        [Required]
        public required string Title { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
