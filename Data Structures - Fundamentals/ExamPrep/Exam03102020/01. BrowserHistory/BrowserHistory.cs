namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private readonly List<ILink> links;

        public BrowserHistory()
        {
            this.links = new List<ILink>();
        }

        public int Size => this.links.Count;

        public void Clear() => this.links.Clear();

        public bool Contains(ILink link) => this.links.Contains(link);

        public ILink DeleteFirst()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            ILink result = this.links[0];
            this.links.RemoveAt(0);

            return result;
        }

        public ILink DeleteLast()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            ILink result = this.links[this.Size - 1];
            this.links.RemoveAt(this.Size - 1);

            return result;
        }

        public ILink GetByUrl(string url)
        {
            foreach (var link in this.links)
            {
                if (link.Url == url)
                {
                    return link;
                }
            }

            return null;
        }

        public ILink LastVisited()
        {
            return this.Size == 0 
                ? throw new InvalidOperationException() 
                : this.links[this.Size - 1];
        }

        public void Open(ILink link)
        {
            this.links.Add(link);
        }

        public int RemoveLinks(string url)
        {
            int count = 0;
            for (int i = this.Size - 1; i >= 0; i--)
            {
                if (this.links[i].Url.ToLower().Contains(url.ToLower()))
                {
                    this.links.RemoveAt(i);
                    count++;
                }
            }

            return count == 0 
                ? throw new InvalidOperationException() 
                : count;
        }

        public ILink[] ToArray()
        {
            ILink[] result = new ILink[this.Size];
            for (int i = this.Size - 1, j = 0; i >= 0; i--, j++)
            {
                result[j] = this.links[i];
            }

            return result;
        }

        public List<ILink> ToList()
        {
            List<ILink> result = new List<ILink>();
            for (int i = this.Size - 1; i >= 0; i--)
            {
                result.Add(this.links[i]);
            }

            return result;
        }

        public string ViewHistory()
        {
            StringBuilder history = new StringBuilder();

            for (int i = this.Size - 1; i >= 0; i--)
            {
                history
                    .Append($"-- {this.links[i].Url} {this.links[i].LoadingTime}s").AppendLine();
            }

            return history.Length == 0 
                ? "Browser history is empty!" 
                : history.ToString();
        }
    }
}
