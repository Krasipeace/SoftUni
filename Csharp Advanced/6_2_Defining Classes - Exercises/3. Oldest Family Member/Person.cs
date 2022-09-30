﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        public string Name { get { return name; } set { name = value; } }
        public int Age { get{ return age; } set { age = value; } }

        public Person()
        {
            Name = "No name";
            Age = 1;
        }
        public Person(int age)
        {
            Name = "No name";
            Age = age;
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
