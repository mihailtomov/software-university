using StorageMaster.Models.Products;
using StorageMaster.Models.Storage.Contracts;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Storage
{
    public abstract class Storage : IStorage
    {
        private readonly Vehicle[] garage;
        private readonly List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = vehicles.ToArray();
            this.products = new List<Product>();
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage.ToList().AsReadOnly();

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();


        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            if (!deliveryLocation.garage.Any(s => s == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            Vehicle freeSlot = deliveryLocation.garage.First(s => s == null);
            int indexOfFreeSlot = Array.FindIndex(deliveryLocation.garage, i => i == freeSlot);
            deliveryLocation.garage[indexOfFreeSlot] = vehicle;
            return indexOfFreeSlot;       
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);
            int numberOfUnloadedProducts = 0;

            while (!vehicle.IsEmpty && !IsFull)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);
                numberOfUnloadedProducts++;
            }

            return numberOfUnloadedProducts;
        }
    }
}
