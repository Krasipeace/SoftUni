using _01.Two_Three;

using System;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("A");
            tree.Insert("E");
            tree.Insert("D");
            tree.Insert("B");
            tree.Insert("F");
            tree.Insert("G");
            tree.Insert("C");
            Console.WriteLine(tree);

            var integerTree = new TwoThreeTree<Integers>();
            integerTree.Insert(new Integers(5));
            integerTree.Insert(new Integers(3));
            integerTree.Insert(new Integers(7));
            integerTree.Insert(new Integers(2));
            integerTree.Insert(new Integers(4));
            integerTree.Insert(new Integers(6));
            integerTree.Insert(new Integers(8));
            integerTree.Insert(new Integers(1));
            integerTree.Insert(new Integers(20));
            integerTree.Insert(new Integers(50));
            integerTree.Insert(new Integers(35));
            integerTree.Insert(new Integers(99));
            integerTree.Insert(new Integers(100));
            Console.WriteLine(integerTree);
        }
        #region IntTree
        private class Integers : IComparable<Integers>
        {
            public Integers(int value)
            {
                this.Value = value;
            }

            public int Value { get; set; }

            public int CompareTo(Integers other)
            {
                return this.Value.CompareTo(other.Value);
            }

            public override string ToString()
            {
                return this.Value.ToString();
            }
        }
        #endregion
    }
}
