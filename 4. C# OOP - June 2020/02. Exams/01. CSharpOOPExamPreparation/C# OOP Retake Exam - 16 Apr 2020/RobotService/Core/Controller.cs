using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Enumerations;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private Dictionary<string, IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<string, IProcedure>();
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!this.procedures.ContainsKey("Charge"))
            {
                this.procedures["Charge"] = new Charge();
            }

            return GetDoServiceMessage(robotName, procedureTime, this.procedures["Charge"], OutputMessages.ChargeProcedure);
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!this.procedures.ContainsKey("Chip"))
            {
                this.procedures["Chip"] = new Chip();
            }
            return GetDoServiceMessage(robotName, procedureTime, this.procedures["Chip"], OutputMessages.ChipProcedure);
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);

            IProcedure currProcedure = null;

            switch (procedureTypeEnum)
            {
                case ProcedureType.Charge:
                    currProcedure = this.procedures["Charge"];
                    break;
                case ProcedureType.Chip:
                    currProcedure = this.procedures["Chip"];
                    break;
                case ProcedureType.Polish:
                    currProcedure = this.procedures["Polish"];
                    break;
                case ProcedureType.Rest:
                    currProcedure = this.procedures["Rest"];
                    break;
                case ProcedureType.TechCheck:
                    currProcedure = this.procedures["TechCheck"];
                    break;
                case ProcedureType.Work:
                    currProcedure = this.procedures["Work"];
                    break;           
            }

            return currProcedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            Enum.TryParse(robotType, out RobotType robotTypeEnum);

            IRobot robot = null;

            switch (robotTypeEnum)
            {
                case RobotType.HouseholdRobot: 
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotType.PetRobot:
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotType.WalkerRobot:
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
            }

            if (robot == null)
            {
                string msg = string.Format(ExceptionMessages.InvalidRobotType, robotType);
                throw new ArgumentException(msg);
            }

            this.garage.Manufacture(robot);
            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!this.procedures.ContainsKey("Polish"))
            {
                this.procedures["Polish"] = new Polish();
            }

            return GetDoServiceMessage(robotName, procedureTime, this.procedures["Polish"], OutputMessages.PolishProcedure);
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!this.procedures.ContainsKey("Rest"))
            {
                this.procedures["Rest"] = new Rest();
            }

            return GetDoServiceMessage(robotName, procedureTime, this.procedures["Rest"], OutputMessages.RestProcedure);
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot robot = this.garage.Robots[robotName];
            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }         
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!this.procedures.ContainsKey("TechCheck"))
            {
                this.procedures["TechCheck"] = new TechCheck();
            }

            return GetDoServiceMessage(robotName, procedureTime, this.procedures["TechCheck"], OutputMessages.TechCheckProcedure);
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!this.procedures.ContainsKey("Work"))
            {
                this.procedures["Work"] = new Work();
            }

            return GetDoServiceMessage(robotName, procedureTime, this.procedures["Work"], OutputMessages.WorkProcedure);
        }

        private string GetDoServiceMessage
            (string robotName, int procedureTime, IProcedure procedure, string message)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot robot = this.garage.Robots[robotName];
            procedure.DoService(robot, procedureTime);

            string procedureType = procedure.GetType().Name;

            if (procedureType != "Work")
            {
                return string.Format(message, robotName);
            }
            else
            {
                return string.Format(message, robotName, procedureTime);
            }
        }
    }
}
