using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T1, T2>
    {
        private T1 Item1;
        private T2 Item2;

        public Tuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
