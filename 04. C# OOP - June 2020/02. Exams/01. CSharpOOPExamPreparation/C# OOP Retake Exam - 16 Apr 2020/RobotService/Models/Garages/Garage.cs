using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private Dictionary<string, IRobot> robots;
        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (this.Robots.ContainsKey(robot.Name))
            {
                string msg = string.Format(ExceptionMessages.ExistingRobot, robot.Name);
                throw new ArgumentException(msg);
            }

            this.robots[robot.Name] = robot;
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.Robots.ContainsKey(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot robot = this.robots[robotName];
            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
