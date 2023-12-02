using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.TaskManager
{
    public class TaskManager : ITaskManager
    {
        private LinkedList<Task> unexecutedTasks;
        private HashSet<Task> executedTasks;
        private Dictionary<string, Task> tasksById;

        public TaskManager()
        {
            this.unexecutedTasks = new LinkedList<Task>();
            this.executedTasks = new HashSet<Task>();
            this.tasksById = new Dictionary<string, Task>();
        }

        public int Size()
            => tasksById.Count;

        public bool Contains(Task task)
            => tasksById.ContainsKey(task.Id);

        public void AddTask(Task task)
        {
            this.unexecutedTasks.AddLast(task);
            this.tasksById.Add(task.Id, task);
        }

        public void DeleteTask(string taskId)
        {
            if (!tasksById.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var taskToDelete = tasksById[taskId];
            tasksById.Remove(taskId);

            if (executedTasks.Contains(taskToDelete))
            {
                executedTasks.Remove(taskToDelete);
            }
            else
            {
                unexecutedTasks.Remove(taskToDelete);
            }
        }

        public Task ExecuteTask()
        {
            if (unexecutedTasks.Count == 0)
            {
                throw new ArgumentException();
            }

            var taskToExecute = unexecutedTasks.First.Value;

            unexecutedTasks.RemoveFirst();
            executedTasks.Add(taskToExecute);

            return taskToExecute;
        }

        public void RescheduleTask(string taskId)
        {
            if (!tasksById.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var taskToReschedule = tasksById[taskId];

            executedTasks.Remove(taskToReschedule);
            unexecutedTasks.AddLast(taskToReschedule);
        }

        public Task GetTask(string taskId)
        {
            if (!tasksById.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            return tasksById[taskId];
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
            => tasksById.Values
                .OrderByDescending(t => t.EstimatedExecutionTime)
                .ThenBy(t => t.Name.Length)
                .ToList();

        public IEnumerable<Task> GetDomainTasks(string domain)
        {
            var tasks = unexecutedTasks
                .Where(t => t.Domain == domain)
                .ToList();

            if (tasks.Count == 0)
            {
                throw new ArgumentException();
            }

            return tasks;
        }

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
            => unexecutedTasks
                .Where(t => t.EstimatedExecutionTime >= lowerBound && t.EstimatedExecutionTime <= upperBound)
                .ToList();
    }
}
