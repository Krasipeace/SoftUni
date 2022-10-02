using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
    {
        public T Type { get; }

        public Box(T type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return $"{Type.GetType().FullName}: {Type}";
        }
    }
}
