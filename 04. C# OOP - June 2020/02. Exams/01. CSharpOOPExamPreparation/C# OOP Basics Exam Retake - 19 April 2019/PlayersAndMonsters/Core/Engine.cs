using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IManagerController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new ManagerController();
        }

        public void Run()
        {
            string command;

            while ((command = this.reader.ReadLine()) != "Exit")
            {
                try
                {
                    string[] args = command.Split();
                    string currCommand = args[0];
                    string message = string.Empty;

                    if (currCommand == "AddPlayer")
                    {
                        string playerType = args[1];
                        string playerUsername = args[2];
                        message = this.controller.AddPlayer(playerType, playerUsername);
                    }
                    if (currCommand == "AddCard")
                    {
                        string cardType = args[1];
                        string cardName = args[2];
                        message = this.controller.AddCard(cardType, cardName);
                    }
                    if (currCommand == "AddPlayerCard")
                    {
                        string username = args[1];
                        string cardName = args[2];
                        message = this.controller.AddPlayerCard(username, cardName);
                    }
                    if (currCommand == "Fight")
                    {
                        string attackUser = args[1];
                        string enemyUser = args[2];
                        message = this.controller.Fight(attackUser, enemyUser);
                    }
                    if (currCommand == "Report")
                    {
                        message = this.controller.Report();
                    }

                    this.writer.WriteLine(message);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }
    }
}
