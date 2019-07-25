using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public interface ITravelStrategy //интерфейс стратегий
    {
        string Travel(List<string> places);
    }

    public class CarTravelStrategy : ITravelStrategy //конкретная реализация интерфейса ITravelStrategy
    {
        public string Travel(List<string> places) //конкретная реализация метода интерфейса ITravelStrategy
        {
            string result = "Car go:";
            foreach(string place in places)
            {
                result += place + ", ";
            }

            return result;
        }
    }

    public class BusTravelStrategy : ITravelStrategy //конкретная реализация интерфейса ITravelStrategy
    {
        public string Travel(List<string> places) //конкретная реализация метода интерфейса ITravelStrategy
        {
            string result = "Bus go:";
            foreach (string place in places)
            {
                result += place + ", ";
            }

            return result;
        }
    }

    public class MotorbykeTravelStrategy : ITravelStrategy //конкретная реализация интерфейса ITravelStrategy
    {
        public string Travel(List<string> places) //конкретная реализация метода интерфейса ITravelStrategy
        {
            string result = "Motorbyke go:";
            foreach (string place in places)
            {
                result += place + ", ";
            }

            return result;
        }
    }

    public class Trip //контекст в которм используется интерфейс ITravelStrategy
    {
        private ITravelStrategy _travelStrategy; //используемая стратегия

        public Trip(){}
        public Trip(ITravelStrategy travelStrategy)
        {
            _travelStrategy = travelStrategy;
        }

        public void SetStrategy(ITravelStrategy travelStrategy) //метод задачи стратегий
        {
            _travelStrategy = travelStrategy;
        }

        public void GoToTrip()
        {
            var places = new List<string> { "Balhash", "Almaty", "Kostanai", "Aktau" };
            string result = _travelStrategy.Travel(places); //применение стратегий

            Console.WriteLine(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Trip trip = new Trip();
            CarTravelStrategy carTravel = new CarTravelStrategy();
            BusTravelStrategy busTravel = new BusTravelStrategy();
            MotorbykeTravelStrategy motorbykeTravel = new MotorbykeTravelStrategy();

            trip.SetStrategy(carTravel);
            trip.GoToTrip();
            trip.SetStrategy(busTravel);
            trip.GoToTrip();
            trip.SetStrategy(motorbykeTravel);
            trip.GoToTrip();
        }
    }
}
