using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП.Terminal
{
    public class AddPlayer : CommandInterface
    {
        private UserService service;
        List<string> allowsType;
        public AddPlayer(UserService service)
        {
            this.service = service;
            allowsType = new List<string>();
            allowsType.Add("Base");
            allowsType.Add("Premium");
            allowsType.Add("Safe");
        }
        public void Execute() 
        {
            AddPlayerCommand();
        }
        public void AddPlayerCommand()
        {
            Console.WriteLine("Write name of new user:");
            string name = Console.ReadLine();
            Console.WriteLine("Write type of new user");
            Console.WriteLine("Allows Type:");
            foreach(string Type in allowsType)
            {
                Console.WriteLine(Type);
            }
            bool typeChooseIsCorrect = false;
            string typeOfUser;
            do
            {
                Console.WriteLine("Write type of new user");
                typeOfUser = Console.ReadLine();
                foreach (string Type in allowsType)
                {
                    if(typeOfUser == Type)
                    {
                        typeChooseIsCorrect = true;
                    }
                }
            } while(!typeChooseIsCorrect);
            service.createAccount(name, typeOfUser);
        }
        public string GetName()
        {
            return "AddPlayer";
        }
        public string GetDescription() 
        {
            return "This command can create a new user";
        }
        public void ShowAllUsers()
        {

        }
        public void ShowPlayerStats()
        {

        }
        public void PlayGameCommand()
        {

        }
        public void GetHelp()
        {

        }
        public void ShowGameOfPlayer()
        {

        }
    }
}
