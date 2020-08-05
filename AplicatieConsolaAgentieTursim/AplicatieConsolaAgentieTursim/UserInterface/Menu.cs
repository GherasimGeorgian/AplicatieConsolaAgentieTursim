using AplicatieConsolaAgentieTursim.Model;
using System;
using System.Collections.Generic;

namespace AplicatieConsolaAgentieTursim.UI
{
    class Menu
    {
        private string menuName;

        private List<KeyValuePair<string, ICommand>> commands = new List<KeyValuePair<string, ICommand>>();

        public Menu(string menuName)
        {
            this.menuName = menuName;
            
        }

        public string GetName()
        {
            return menuName;
        }

        public List<KeyValuePair<string, ICommand>> GetCommands()
        {
            return commands;
        }

        public void AddCommand(String descriere, ICommand command)
        {
         
                commands.Add(new KeyValuePair<string, ICommand>(descriere, command));
        }

        public void Execute()
        {
            foreach (KeyValuePair<string, ICommand> pair in commands)
            {
                System.Console.WriteLine(pair.Key);
            }
            System.Console.WriteLine();
        }
    }
}
