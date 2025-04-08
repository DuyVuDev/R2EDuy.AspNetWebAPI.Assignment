using System.ComponentModel.DataAnnotations;

namespace R2EDuy.AspNetWebAPI.Assignment.Models
{
    public class TaskItemRequestAdd
    {
        [Required]
        public required string Title { get; set; }
    }
}
