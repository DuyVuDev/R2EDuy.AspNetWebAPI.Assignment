using R2EDuy.AspNetWebAPI.Assignment.Models;
using R2EDuy.AspNetWebAPI.Assignment.Repositories;

namespace R2EDuy.AspNetWebAPI.Assignment.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TaskItem CreateTask(TaskItemRequestAdd newTaskItem)
        {
            var newTask = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = newTaskItem.Title,
                IsCompleted = false,
            };
            _taskRepository.Add(newTask);
            return newTask;
        }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return _taskRepository.GetAll();
        }

        public TaskItem? GetTaskById(Guid id)
        {
            return _taskRepository.GetById(id);
        }

        public bool DeleteTask(Guid id)
        {
            var task = _taskRepository.GetById(id);
            if (task != null)
            {
                _taskRepository.Remove(id);
                return true;
            }
            return false;
        }

        public TaskItem? UpdateTask(Guid id, TaskItemRequestUpdate edittedTaskItem)
        {
            var task = _taskRepository.GetById(id);
            if (task != null)
            {
                task.Title = edittedTaskItem.Title;
                task.IsCompleted = edittedTaskItem.IsCompleted;

                _taskRepository.Update(task);
                
            }
            return task;
        }

        public IEnumerable<TaskItem>? BulkAddTasks(IEnumerable<TaskItemRequestAdd> newTasks)
        {
            List<TaskItem> result = new List<TaskItem>();

            foreach (TaskItemRequestAdd task in newTasks)
            {
                var taskName = task.Title;
                if (taskName.Equals(string.Empty))
                {
                    return null;
                }

                var newTask = new TaskItem()
                {
                    Id = Guid.NewGuid(),
                    Title = taskName,
                    IsCompleted = false,
                };
                result.Add(newTask);
            }

            _taskRepository.AddMultiple(result);
            return result;
        }

        public bool BulkDeleteTasks(IEnumerable<Guid> ids)
        {
            if (_taskRepository.ContainsAllTasksByIds(ids))
            {
                _taskRepository.RemoveMultiple(ids);
                return true;
            }
            return false;
        }
    }
}
