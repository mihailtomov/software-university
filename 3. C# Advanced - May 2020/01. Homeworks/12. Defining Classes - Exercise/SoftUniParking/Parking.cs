using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count 
        {
            get 
            {
                return this.cars.Count;
            }
        }

        public string AddCar(Car Car)
        {
            if (this.cars.Any(c => c.RegistrationNumber == Car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.cars.Count >= this.capacity)
            {
                return "Parking is full!";
            }
            else
            {
                this.cars.Add(Car);
                return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (this.cars.Any(c => c.RegistrationNumber == RegistrationNumber))
            {
                this.cars.Remove(this.cars.FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber));
                return $"Successfully removed {RegistrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string RegistrationNumber)
        {
            Car car = this.cars.FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber);
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var registrationNumber in RegistrationNumbers)
            {
                this.cars.RemoveAll(c => c.RegistrationNumber == registrationNumber);
            }
        }
    }
}
