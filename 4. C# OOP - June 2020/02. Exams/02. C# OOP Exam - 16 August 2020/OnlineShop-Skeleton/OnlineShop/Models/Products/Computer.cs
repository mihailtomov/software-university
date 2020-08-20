using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance => this.CalculatePerformance();

        public override decimal Price => base.Price + this.Components.Sum(c => c.Price) + this.Peripherals.Sum(p => p.Price);

        private double CalculatePerformance()
        {
            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }

            return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
        }

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                string msg = string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                string msg = string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {        
            if (this.Components.Count == 0 || !this.Components.Any(c => c.GetType().Name == componentType))
            {
                string msg = string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            IComponent componentToRemove = this.Components.First(c => c.GetType().Name == componentType);
            this.components.Remove(componentToRemove);
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.Peripherals.Count == 0 || !this.Peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                string msg = string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            IPeripheral peripheralToRemove = this.Peripherals.First(c => c.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Average(p => p.OverallPerformance):f2}):");

            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
