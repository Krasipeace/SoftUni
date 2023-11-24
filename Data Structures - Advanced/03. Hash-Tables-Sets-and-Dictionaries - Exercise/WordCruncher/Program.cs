namespace WordCruncher
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var inputText = Console.ReadLine().Split(", ");
            var wordToComplete = Console.ReadLine();
            var wordCruncher = new WordCruncher(inputText, wordToComplete);

            foreach (var path in wordCruncher.CompleteWord())
            {
                Console.WriteLine(path);
            }
        }
    }

    class WordCruncher
    {
        private class Node
        {
            public string InputText { get; set; }
            public List<Node> Nodes { get; set; }

            public Node(string inputText, List<Node> nodes)
            {
                this.InputText = inputText;
                this.Nodes = nodes;
            }
        }

        private List<Node> groupOfNodes;

        public WordCruncher(string[] inputText, string wordToComplete)
        {
            this.groupOfNodes = this.GenerateGroupOfNodes(inputText, wordToComplete, new List<int>());
        }

        private List<Node> GenerateGroupOfNodes(string[] inputText, string wordToComplete, List<int> result)
        {
            if (string.IsNullOrEmpty(wordToComplete) || inputText.Length == 0)
            {
                return null;
            }

            var list = new List<Node>();

            for (int i = 0; i < inputText.Length; i++)
            {
                if (!result.Contains(i))
                {
                    var word = inputText[i];

                    if (wordToComplete.StartsWith(word))
                    {
                        result.Add(i);
                        var nextNode = this.GenerateGroupOfNodes(inputText, wordToComplete.Substring(word.Length), result);
                        result.Remove(i);
                        list.Add(new Node(word, nextNode));
                    }
                }
            }

            return list;
        }

        public IEnumerable<string> CompleteWord()
        {
            var result = new HashSet<string>();
            this.GeneratePaths(this.groupOfNodes, new List<string>(), result);

            return result;
        }

        private void GeneratePaths(List<Node> groupOfNodes, List<string> currentPath, HashSet<string> result)
        {
            if (groupOfNodes == null)
            {
                result.Add(string.Join(" ", currentPath));

                return;
            }

            foreach (var node in groupOfNodes)
            {
                currentPath.Add(node.InputText);

                this.GeneratePaths(node.Nodes, currentPath, result);

                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }
}
