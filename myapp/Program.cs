using System;
using myapp.models;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("email@gmail.com", "secret");
            user.Orders.ToString();
            Race race2 = new Race();
            race2.Begin();
            
        }
    }
}
