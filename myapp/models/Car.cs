using System;

namespace myapp.models
{
    public class Car
    {
        public double Speed {get; set;} = 100;
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
}