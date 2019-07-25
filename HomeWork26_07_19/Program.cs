using System;
using System.Collections.Generic;

namespace HomeWork26_07_19
{
    public interface IUser //интерфейс обзервера
    {
        void Update(ITumbler tumbler);
    }

    public interface ITumbler //интерфейс тумблера который будет оповещать о новинках
    {
        string News { get; set; } //новость которая будет оповещаться
        void Attach(IUser user); //метод подписки на рассылку
        void Detach(IUser user); //метод отписки на рассылку
        void Notify(); //метод оповещение
    }

    public class Tumbler : ITumbler //конкретная реализация тумблера
    {
        private string _news = "There is must be some news"; //новость которая будеть рассылаться
        private List<IUser> _users = new List<IUser>(); //список клиентов которым будет отправляться рассылка
        public string News
        {
            get
            {
                return _news;
            }
            set
            {
                _news = value;
            }
        }

        public void Attach(IUser user)
        {
            _users.Add(user);
        }

        public void Detach(IUser user)
        {
            _users.Remove(user);
        }

        public void Notify()
        {
            foreach(var user in _users)
            {
                user.Update(this);
            }
        }
    }

    public class User : IUser //конкретная реализация юзера
    {
        public void Update(ITumbler tumbler)
        {
            Console.WriteLine(tumbler.News);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tumbler tumbler = new Tumbler();
            User user = new User();
            tumbler.Attach(user);
            tumbler.Notify();
        }
    }
}
