using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_4_ООП.Terminal
{
    public class HELP: CommandInterface
    {
        private List<CommandInterface> listOfCommands;
        public HELP(List<CommandInterface> listOfCommands)
        {
            this.listOfCommands = listOfCommands;
        }
        public void Execute()
        {
            GetHelp();
        }
        public void GetHelp()
        {
            foreach (var command in listOfCommands) 
            {
                Console.WriteLine(command.GetName() + "\nDescription: "+command.GetDescription());
            }
        }
        public string GetName()
        {
            return "Help";
        }
        public string GetDescription() 
        {
            return "This command show all of allows commands and their meanings";
        }
        public void ShowAllUsers()
        {

        }
        public void AddPlayerCommand()
        {

        }
        public void ShowPlayerStats()
        {

        }
        public void PlayGameCommand()
        {

        }
    }
}
