using System;

namespace myapp.models
{
    public interface IEmailSender
    {
        void SendMessage(string receiver, string title, string message);
    }
    public class EmailSender : IEmailSender
    {
        void IEmailSender.SendMessage(string receiver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }
    public interface IDateBase
    {
        bool IsConnected {get;}
        void Connect();
        User GetUser(string emial);
        Order GetOrder(int id);
        void SaveChanges();
    }

    public class  Datebase : IDateBase
    {
        public bool IsConnected => throw new NotImplementedException();

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string emial)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

    public interface IOrderProcesor
    {
        void ProcesOrder(string email, int orderId);
    }

    public class OrderProcesor : IOrderProcesor
    {
        private readonly IDateBase _database;
        private readonly IEmailSender _emailSender;
        public OrderProcesor(IDateBase datebase, IEmailSender EmailSender)
        {
           _database = datebase;
           _emailSender = EmailSender;  
        }
        public void ProcesOrder(string email, int orderId)
        {
            User user = _database.GetUser(email);
            Order order = _database.GetOrder(orderId);
            user.PurchaseOrder(order);
            _database.SaveChanges();
            _emailSender.SendMessage(email, "Order purchased", "You've purchased and order");
        }
    }

    public class FakeEmailSender : IEmailSender
    {
        void IEmailSender.SendMessage(string receiver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeDatabase : IDateBase
    {
        bool IDateBase.IsConnected => throw new NotImplementedException();

        void IDateBase.Connect()
        {
            throw new NotImplementedException();
        }

        Order IDateBase.GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        User IDateBase.GetUser(string emial)
        {
            throw new NotImplementedException();
        }

        void IDateBase.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
    public class Shop
    {
        public void CompleteOrder()
        {
        IDateBase database = new Datebase();
        IEmailSender emailSender = new EmailSender();
        IOrderProcesor orderProcesor = new OrderProcesor(database, emailSender);
        }
       
       public void CompleteFakeOrder()
        {
        IDateBase database = new FakeDatabase();
        IEmailSender emailSender = new FakeEmailSender();
        IOrderProcesor orderProcesor = new OrderProcesor(database, emailSender);
        }

    }
}