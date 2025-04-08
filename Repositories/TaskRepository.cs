using R2EDuy.AspNetWebAPI.Assignment.Models;

namespace R2EDuy.AspNetWebAPI.Assignment.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private static List<TaskItem> _tasks = new List<TaskItem>() {
            new TaskItem(){ Id = Guid.NewGuid(), Title = "quet nha", IsCompleted = true},
            new TaskItem(){ Id = Guid.NewGuid(), Title = "rua bat", IsCompleted = false},
            new TaskItem(){ Id = Guid.NewGuid(), Title = "nau com", IsCompleted = true}
        };

        public IEnumerable<TaskItem> GetAll() => _tasks;
        public TaskItem? GetById(Guid id) => _tasks.FirstOrDefault(t => t.Id.Equals(id));
        public void Add(TaskItem newTask) => _tasks.Add(newTask);
        public void Remove(Guid id) => _tasks.RemoveAll(t => t.Id.Equals(id));
        public TaskItem? Update(TaskItem updatedTask)
        {
            var task = _tasks.FirstOrDefault(t => t.Id.Equals(updatedTask.Id));

            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.IsCompleted = updatedTask.IsCompleted;
            }
            return task;
        }
        public void AddMultiple(IEnumerable<TaskItem> newTasks) => _tasks.AddRange(newTasks);
        public void RemoveMultiple(IEnumerable<Guid> ids)
        {
            var idSet = new List<Guid>(ids);
            _tasks.RemoveAll(t => idSet.Contains(t.Id));
        }

        public bool ContainsAllTasksByIds(IEnumerable<Guid> taskIds)
        {
            return taskIds.All(id => _tasks.Any(t => t.Id == id));
        }
    }
}
