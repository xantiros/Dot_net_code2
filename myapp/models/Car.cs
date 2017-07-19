using System;
using System.Collections.Generic;

namespace myapp.models
{
    public class Car
    {
        public double Speed {get; protected set;} = 100;
        public double Acceleration{get; protected set;} = 10;
        public void Start()
        {
            Console.WriteLine("Turning on the engine...");
            Console.WriteLine($"Running at: {Speed} km/h");
        }
        public void Stop()
        {
            Console.WriteLine("Stoping the car...");
        } 
        public virtual void Accelerate()
        {
            Console.WriteLine("Accelerating...");
            Speed += Acceleration;
            Console.WriteLine($"Running at: {Speed} km/h");
        }
    }

    public class Truck : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a truck...");
            Speed += Acceleration;
            Console.WriteLine($"Running the truck at: {Speed} km/h");
        }
    }
    public class SportCar : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerating a Sport Car...");
            Speed += Acceleration;
            Console.WriteLine($"Running the sport car at: {Speed} km/h");
        }
    }
    public class Race
    {
        public void Begin()
        {
            SportCar sportCar = new SportCar();
            Truck truck = new Truck();

            List<Car> cars = new List<Car>
            {
                sportCar, truck
            };

            foreach(Car car in cars)
            {
                car.Start();
                car.Accelerate();
            }
        }
    }
}