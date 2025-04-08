using Microsoft.AspNetCore.Mvc;
using R2EDuy.AspNetWebAPI.Assignment.Models;
using R2EDuy.AspNetWebAPI.Assignment.Service;

namespace R2EDuy.AspNetWebAPI.Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskItemRequestAdd task)
        {
            var createdTask = _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            var task = _taskService.GetTaskById(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            var deleted = _taskService.DeleteTask(id);
            return deleted ? Ok("Task deleted successfully!") : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody] TaskItemRequestUpdate task)
        {
            var updatedTask = _taskService.UpdateTask(id, task);
            return updatedTask == null ? NotFound() : Ok(updatedTask);
        }

        [HttpPost("bulk-create")]
        public IActionResult BulkAddTasks([FromBody] IEnumerable<TaskItemRequestAdd> newTasks)
        {
            var createdTasks = _taskService.BulkAddTasks(newTasks);
            return createdTasks == null ? BadRequest() : Ok(createdTasks);
        }

        [HttpDelete("bulk-delete")]
        public IActionResult BulkDeleteTasks([FromBody] IEnumerable<Guid> taskIds)
        {
            var deleted = _taskService.BulkDeleteTasks(taskIds);
            return deleted ? Ok("Selected tasks deleted successfully!") : BadRequest();
        }
    }

}
