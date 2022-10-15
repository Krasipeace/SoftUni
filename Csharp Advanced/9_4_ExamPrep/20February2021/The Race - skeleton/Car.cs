using System;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Car
    { 
        private string name;
        private int speed;     
        public Car(string name, int speed)
        {
            this.Name = name;
            this.Speed = speed;          
        }
        public string Name { get { return name; } set { name = value; } }
        public int Speed { get { return speed; } set { speed = value; } } 
    }
}
