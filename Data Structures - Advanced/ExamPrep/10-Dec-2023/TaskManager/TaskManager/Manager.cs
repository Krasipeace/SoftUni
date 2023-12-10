using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    public class Manager : IManager
    {
        private Dictionary<string, Task> tasks;

        public Manager()
        {
            this.tasks = new Dictionary<string, Task>();
        }

        public int Size()
            => this.tasks.Count;

        public bool Contains(string taskId)
            => this.tasks.ContainsKey(taskId);

        public void AddTask(Task task)
        {
            if (this.tasks.ContainsKey(task.Id))
            {
                throw new ArgumentException();
            }

            this.tasks.Add(task.Id, task);
        }

        public void RemoveTask(string taskId)
        {
            if (!this.tasks.ContainsKey(taskId))
            {
                throw new ArgumentException();
            }

            this.tasks.Remove(taskId);
        }

        public Task Get(string taskId)
        {
            if (!Contains(taskId))
            {
                throw new ArgumentException();
            }

            return this.tasks[taskId];
        }

        public void AddDependency(string taskId, string dependentTaskId)
        {
            if (!Contains(taskId) || !Contains(dependentTaskId))
            {
                throw new ArgumentException();
            }

            if (HasCircularDependency(taskId, dependentTaskId))
            {
                throw new ArgumentException();
            }

            Task task = Get(taskId);
            Task dependentTask = Get(dependentTaskId);

            task.Dependencies.AddLast(dependentTask);
        }

        private bool HasCircularDependency(string taskId, string dependentTaskId)
        {
            Task task = Get(taskId);
            Task dependentTask = Get(dependentTaskId);

            if (task.Dependencies.Contains(dependentTask))
            {
                return true;
            }

            foreach (Task dependency in dependentTask.Dependencies)
            {
                if (HasCircularDependency(taskId, dependency.Id))
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveDependency(string taskId, string dependentTaskId)
        {
            if (!Contains(taskId) || !Contains(dependentTaskId))
            {
                throw new ArgumentException();
            }

            Task task = Get(taskId);
            Task dependentTask = Get(dependentTaskId);

            if (!task.Dependencies.Contains(dependentTask))
            {
                throw new ArgumentException();
            }

            task.Dependencies.Remove(dependentTask);
        }

        public IEnumerable<Task> GetDependencies(string taskId)
        {
            if (!Contains(taskId))
            {
                return new List<Task>();
            }

            Task task = Get(taskId);

            return task.Dependencies;
        }

        public IEnumerable<Task> GetDependents(string taskId)
        {
            if (!Contains(taskId))
            {
                return new List<Task>();
            }

            List<Task> dependents = new List<Task>();

            foreach (Task task in tasks.Values)
            {
                if (task.Dependencies.Any(d => d.Id == taskId))
                {
                    dependents.Add(task);
                }
            }

            return dependents;
        }
    }
}