using System;
using System.Collections.Generic;

namespace myapp.models
{
    public class Car
    {
        public double Speed {get; protected set;} = 100;
        public void Start()
        {
            Console.WriteLine("Turning on the engine...");
            Console.WriteLine($"Running at: {Speed} km/h");
        }
        public void Stop()
        {
            Console.WriteLine("Stoping the car...");
        } 
    }

    public class Truck : Car
    {
    }
    public class SportCar : Car
    {

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
            }
        }
    }
}