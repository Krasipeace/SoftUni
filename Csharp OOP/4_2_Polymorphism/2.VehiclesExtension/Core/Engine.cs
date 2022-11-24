namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;
    using Vehicles.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;
        private readonly ICollection<IVehicle> vehicles;

        private Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
        }

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            this.vehicles.Add(this.BuildVehicle());
            this.vehicles.Add(this.BuildVehicle());
            this.vehicles.Add(this.BuildVehicle());

            int n = int.Parse(this.reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    this.ProcessCommand();
                }
                catch (InsufficientFuelException x)
                {
                    this.writer.WriteLine(x.Message);
                }
                catch (InvalidVehicleTypeException y)
                {
                    this.writer.WriteLine(y.Message);
                }
                catch(InvalidAmountOfRefuelFuelException z)
                {
                    this.writer.WriteLine(z.Message);
                }
                catch(InvalidTankCapacityException q)
                {
                    this.writer.WriteLine(q.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            this.PrintResult();
        }

        private IVehicle BuildVehicle()
        {
            string[] vehicleData = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string vehicleType = vehicleData[0];
            double vehicleFuelQuantity = double.Parse(vehicleData[1]);
            double vehicleFuelConsumption = double.Parse(vehicleData[2]);
            double vehicleTankCapacity = double.Parse(vehicleData[3]);

            IVehicle vehicle = this.vehicleFactory.CreateVehicle(vehicleType, vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);

            return vehicle;
        }
        private void ProcessCommand()
        {
            string[] inputData = this.reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = inputData[0];
            string vehicleType = inputData[1];
            double driveDistance = double.Parse(inputData[2]);

            IVehicle vehicleToProcess = this.vehicles
                .FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicleToProcess == null)
            {
                throw new InvalidVehicleTypeException();
            }

            switch (command)
            {
                case "Drive":
                    writer.WriteLine(vehicleToProcess.Drive(driveDistance));
                    break;
                case "Refuel":
                    vehicleToProcess.Refuel(driveDistance);
                    break;
                case "DriveEmpty":
                    if (vehicleToProcess is Bus busEmpty)
                    {
                        writer.WriteLine(busEmpty.DriveEmpty(driveDistance));
                    }
                    break;
            }
        }

        private void PrintResult()
        {
            foreach (IVehicle vehicle in this.vehicles)
            {
                this.writer.WriteLine(vehicle.ToString());
            }
        }
    }
}
