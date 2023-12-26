using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП.Terminal
{
    public class TerminalClass
    {
        private List<CommandInterface> ListOfCommands;
        public TerminalClass(UserService user_service, GameService game_service) 
        {
            ListOfCommands = new List<CommandInterface>();
            ListOfCommands.Add(new AddPlayer(user_service));
            ListOfCommands.Add(new PlayGame(game_service, user_service));
            ListOfCommands.Add(new ShowUsers(user_service));
            ListOfCommands.Add(new ShowUserStats(user_service));
            ListOfCommands.Add(new HELP(ListOfCommands));
        }
        public void StartTerminal()
        {
            Console.WriteLine("\tHello user");
            string nameOfCommand;
            Console.WriteLine("Write 'Help' if you forgot commands");
            Console.WriteLine("press 'q' if you want exit");
            do
            {
                bool commandWasChoosen = false;
                Console.WriteLine("Please choose command: ");
                nameOfCommand = Console.ReadLine();
                if (nameOfCommand != "q")
                {
                    foreach (CommandInterface command in ListOfCommands)
                    {
                        if (nameOfCommand == command.GetName())
                        {
                            commandWasChoosen = true;
                            command.Execute();
                            break;
                        }
                    }
                    if (!commandWasChoosen)
                    {
                        Console.WriteLine("Command '" + nameOfCommand + "' not founded");
                    }
                }
            } while(nameOfCommand != "q");
        }
    }
}
