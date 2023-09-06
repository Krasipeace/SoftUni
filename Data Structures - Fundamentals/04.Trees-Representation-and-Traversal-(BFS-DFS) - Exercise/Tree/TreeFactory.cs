namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public TreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (string str in input)
            {
                var keys = str.Split(' ').Select(int.Parse).ToArray();
                var parentKey = keys[0];
                var childKey = keys[1];

                this.AddEdge(parentKey, childKey);
            }

            return this.GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!this.nodesByKey.ContainsKey(key))
            {
                this.nodesByKey.Add(key, new IntegerTree(key));
            }

            return this.nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.CreateNodeByKey(parent);
            var childNode = this.CreateNodeByKey(child);

            childNode.AddParent(parentNode);
            parentNode.AddChild(childNode);
        }

        public IntegerTree GetRoot()
        {
            foreach (var item in this.nodesByKey)
            {
                if (item.Value.Parent is null)
                {
                    return item.Value;
                }
            }

            return null;
        }
    }
}
