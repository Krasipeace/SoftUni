using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Car
    {
        private string manufacturer;
        private string model;
        private int year;       
        public Car(string manufacturer, string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;           
        }
        public string Manufacturer { get { return manufacturer; } set { manufacturer = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }        

        public override string ToString()
        {
            return $"{Manufacturer} {Model} ({Year})";
        }
    }
}
