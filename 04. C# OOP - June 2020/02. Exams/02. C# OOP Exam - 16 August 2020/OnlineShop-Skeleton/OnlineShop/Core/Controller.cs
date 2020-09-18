using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(c => c.Id == computerId);

            Enum.TryParse(componentType, out ComponentType componentTypeEnum);

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;

            switch (componentTypeEnum)
            {
                case ComponentType.CentralProcessingUnit:
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.Motherboard:
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.PowerSupply:
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.RandomAccessMemory:
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.SolidStateDrive:
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.VideoCard:
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            computer.AddComponent(component);
            this.components.Add(component);
            string msg = string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            return msg;
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            Enum.TryParse(computerType, out ComputerType computerTypeEnum);

            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            switch (computerTypeEnum)
            {
                case ComputerType.DesktopComputer: 
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case ComputerType.Laptop:
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            this.computers.Add(computer);
            string msg = string.Format(SuccessMessages.AddedComputer, id);
            return msg;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(c => c.Id == computerId);

            Enum.TryParse(peripheralType, out PeripheralType peripheralTypeEnum);

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            switch (peripheralTypeEnum)
            {
                case PeripheralType.Headset:
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Keyboard:
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Monitor:
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Mouse:
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);
            string msg = string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            return msg;
        }

        public string BuyBest(decimal budget)
        {
            if (!this.computers.Any() || !this.computers.Any(c => c.Price <= budget))
            {
                string msg = string.Format(ExceptionMessages.CanNotBuyComputer, budget);
                throw new ArgumentException(msg);
            }

            var filteredComputers = this.computers
                .OrderByDescending(c => c.OverallPerformance)
                .ToList();

            IComputer computerToRemove = filteredComputers.First(c => c.Price <= budget);
            this.computers.Remove(computerToRemove);
            return computerToRemove.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(c => c.Id == id);

            string msg = computer.ToString();
            this.computers.Remove(computer);
            return msg;
        }

        public string GetComputerData(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(c => c.Id == id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(c => c.Id == computerId);

            IComponent component = computer.RemoveComponent(componentType);
            this.components.Remove(component);

            string msg = string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
            return msg;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computers.First(c => c.Id == computerId);

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);

            string msg = string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
            return msg;
        }
    }
}
