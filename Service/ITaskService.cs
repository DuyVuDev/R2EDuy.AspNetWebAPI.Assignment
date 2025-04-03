using R2EDuy.AspNetWebAPI.Assignment.Models;

namespace R2EDuy.AspNetWebAPI.Assignment.Service
{
    public interface ITaskService
    {
        TaskItem CreateTask(TaskItemRequestAdd newTaskItem);
        IEnumerable<TaskItem> GetAllTasks();
        TaskItem? GetTaskById(Guid id);
        bool DeleteTask(Guid id);
        TaskItem? UpdateTask(Guid id, TaskItemRequestUpdate taskItem);
        IEnumerable<TaskItem>? BulkAddTasks(IEnumerable<TaskItemRequestAdd> newTasks);
        bool BulkDeleteTasks(IEnumerable<Guid> ids);
    }
}
