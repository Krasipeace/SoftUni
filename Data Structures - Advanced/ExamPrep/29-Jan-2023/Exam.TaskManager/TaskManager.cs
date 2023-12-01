using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.TaskManager
{
    public class TaskManager : ITaskManager
    {
        private Dictionary<string, Queue<Task>> tasksById;

        public TaskManager()
        {
            tasksById = new Dictionary<string, Queue<Task>>();
        }

        public int Size()
            => tasksById.Count;

        public bool Contains(Task task)
            => tasksById.ContainsKey(task.Id);

        public void AddTask(Task task)
        {
            this.tasksById.Add(task.Id, new Queue<Task>());
            this.tasksById[task.Id].Enqueue(task);
        }

        public void DeleteTask(string taskId)
        {
            var taskToDelete = this.tasksById[taskId].Dequeue() ?? throw new ArgumentException();

            tasksById.Remove(taskToDelete.Id);
        }

        public Task ExecuteTask()
        {
            var taskToExecute = tasksById.First().Value.Dequeue() ?? throw new ArgumentException();
            tasksById.First().Value.Enqueue(taskToExecute);

            return taskToExecute;
        }

        public Task GetTask(string taskId)
        {
            if (tasksById.TryGetValue(taskId, out var taskQueue))
            {
                return taskQueue.Peek();
            }
            throw new ArgumentException();
        }

        public IEnumerable<Task> GetAllTasksOrderedByEETThenByName()
            => tasksById.Values
                .SelectMany(t => t)
                .OrderByDescending(t => t.EstimatedExecutionTime)
                .ThenBy(t => t.Name.Length);

        public void RescheduleTask(string taskId)
        {
            if (!tasksById.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            var taskToReschedule = tasksById[taskId].Dequeue() ?? throw new ArgumentException();
            tasksById[taskId].Enqueue(taskToReschedule);
        }

        public IEnumerable<Task> GetDomainTasks(string domain)
            => tasksById.Values
                .SelectMany(t => t)
                .Where(t => t.Domain == domain)
            ?? throw new ArithmeticException();

        public IEnumerable<Task> GetTasksInEETRange(int lowerBound, int upperBound)
            => tasksById.Values
                .SelectMany(t => t)
                .Where(t => t.EstimatedExecutionTime >= lowerBound && t.EstimatedExecutionTime <= upperBound);
    }
}
