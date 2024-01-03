using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП.Terminal
{
    public class ShowUsers : CommandInterface
    {
        private UserService service;
        public ShowUsers(UserService service)
        {
            this.service = service;
        }
        public void Execute() 
        {
            ShowAllUsers();
        }
        public void ShowAllUsers()
        {
            List <UsersEntity> users = service.ReadAccounts();
            foreach(UsersEntity user in users)
            {
                Console.WriteLine(user.UserName);
            }
        }
        public string GetName()
        {
            return "ShowUsers";
        }
        public string GetDescription() 
        {
            return "This command show all existing users";
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
        public void GetHelp()
        {

        }
        public void ShowGameOfPlayer()
        {

        }
    }
}
