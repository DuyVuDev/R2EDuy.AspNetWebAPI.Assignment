using R2EDuy.AspNetWebAPI.Assignment.Models;

namespace R2EDuy.AspNetWebAPI.Assignment.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem? GetById(Guid id);
        void Add(TaskItem newTask);
        void Remove(Guid id);
        TaskItem? Update(TaskItem updatedTask);
        void AddMultiple(IEnumerable<TaskItem> newTasks);
        void RemoveMultiple(IEnumerable<Guid> ids);
        bool ContainsAllTasksByIds(IEnumerable<Guid> taskIds);
    }

}
