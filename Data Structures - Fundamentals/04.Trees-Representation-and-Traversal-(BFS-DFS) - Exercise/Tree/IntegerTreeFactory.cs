namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            throw new NotImplementedException();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            throw new NotImplementedException();
        }

        public void AddEdge(int parent, int child)
        {
            throw new NotImplementedException();
        }

        public IntegerTree GetRoot()
        {
            throw new NotImplementedException();
        }
    }
}
