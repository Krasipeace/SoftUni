namespace TaskManager
{
    using System.Collections.Generic;

    public class Task
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Assignee { get; set; }

        public int Priority { get; set; }

        public override string ToString()
        {
            return this.Title;
        }

        public LinkedList<Task> Dependencies { get; set; } = new LinkedList<Task>();
    }
}