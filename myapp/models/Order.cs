using System;

namespace myapp.models
{
    public class Order
    {
        public int Id { get; private set; }
        public decimal Price { get; private set; }
        public decimal TaxRate { get; } = 0.23M;
        public decimal TotalPrice { get {return ( 1+ TaxRate) * Price;}}
        public bool isPurchased {get; private set;}
        public Order (int id, decimal price)
        {
            if(price <= 0)
            {
                throw new Exception("Price mus be greater than 0.");
            }
            Id = id;
            Price = price;
        }

        public void Purchase ()
        {
            if(isPurchased) throw new Exception("Order was already purchased.");

            isPurchased = true;
        }
    }
}