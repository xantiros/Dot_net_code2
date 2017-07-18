using System;

namespace myapp.models
{
    public class User
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime UpdateDat { get; private set;}
        public decimal Founds {get; private set;}
        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("bledny email");
            }
            if (Email == email) 
            {
                return;
            }

            Email = email;
            Update();
        }

        public void SetPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("bledny email");
            }
            if (Password == password) 
            {
                return;
            }

            Password = password;
            Update();
        }

        private void Update()
        {
         UpdateDat = DateTime.UtcNow;   
        }

        public void SetAge(int age)
        {
            if(age < 13)
            {
                throw new Exception("Age must be greater or equal 13");
            }
            if (Age == age)
            {
                return;
            }
            Age = age;
            Update();
        }

        public void Activate()
        {
            if(IsActive) return;

            IsActive = true;
        } 
        public void Deactivate()
        {
            if (!IsActive) return;

            IsActive = false;
        }
        
        public void PurchaseOrder(Order order)
        {
            if(!IsActive) throw new Exception("Only acrive user can purchase an order. ");

            decimal orderPrice = order.TotalPrice;
            if (Founds - orderPrice < 0)
            {
                throw new Exception("You don't have enough money.");
            }
            order.Purchase();
            Founds -= orderPrice;
            Update();
        }

        public void IncreaseFounds(decimal founds)
        {
            if (founds <= 0) throw new Exception("Founds mus be greater than 0");

            Founds += founds;
            Update();
        }
    }
}