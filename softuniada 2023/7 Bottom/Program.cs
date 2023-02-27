namespace _7_Bottom
{
    using System;
    using System.Collections.Generic;

    class Edge
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Weight { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < e; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                int start = int.Parse(tokens[0]);
                int end = int.Parse(tokens[1]);
                int weight = int.Parse(tokens[2]);

                edges.Add(new Edge { Start = start, End = end, Weight = weight });
            }

            int minWeight = FindMinWeight(edges, v);
            Console.WriteLine(minWeight);
        }

        static int FindMinWeight(List<Edge> edges, int v)
        {
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));

            int[] parent = new int[v + 1];
            for (int i = 1; i <= v; i++)
            {
                parent[i] = i;
            }

            int count = 0;
            for (int i = 0; i < edges.Count; i++)
            {
                int start = edges[i].Start;
                int end = edges[i].End;
                int weight = edges[i].Weight;

                int root1 = Find(start, parent);
                int root2 = Find(end, parent);

                if (root1 != root2)
                {
                    parent[root1] = root2;
                    count++;
                    if (count == v - 1)
                    {
                        return weight + 1;
                    }
                }
            }

            return 2;
        }

        static int Find(int node, int[] parent)
        {
            if (node != parent[node])
            {
                parent[node] = Find(parent[node], parent);
            }

            return parent[node];
        }
    }
}