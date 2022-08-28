﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get { return this.make; } private set { this.make = value; } }
        public string Model { get { return this.model; } private set { this.model = value; } }
        public int Year { get { return this.year; } private set { this.year = value; } }
        public double FuelQuantity { get { return this.fuelQuantity; } private set { this.fuelQuantity = value; } }
        public double FuelConsumption { get { return this.fuelConsumption; } private set { this.fuelConsumption = value; } }
        public Engine Engine { get { return this.engine; } private set { this.engine = value; } }
        public Tire[] Tires { get { return this.tires; } private set { this.tires = value; } }

    }
}
