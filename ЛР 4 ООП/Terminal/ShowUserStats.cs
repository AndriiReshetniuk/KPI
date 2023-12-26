using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП.Terminal
{
    public class ShowUserStats : CommandInterface
    {
        public UserService service;
        public ShowUserStats(UserService service)
        {
            this.service = service;
        }
        public void Execute() 
        {
            ShowPlayerStats();
        }
        public void ShowPlayerStats()
        {
            UsersEntity user;
            do
            {
                Console.WriteLine("Write name of user for get stats");
                user = service.ReadAccountByName(Console.ReadLine());
            } while (user == null);
            Console.WriteLine(user.UserName + "\t:");
            Console.WriteLine("Type of user: " + user.typeOfUsers);
            Console.WriteLine("Current raiting: " +user.CurrentRaiting);
            Console.WriteLine("Count of games: " + user.GamesCount);
            Console.WriteLine("Count of winning games: " + user.countOfWinningGames);
            Console.WriteLine("Count of Lost games: " + user.countOfLostGames);
            Console.WriteLine("Information about every round of "+ user.UserName);
            AccountFactory factory = new AccountFactory();
            BaseAccount copyAccount = factory.CreateAccount(user.UserName, user.typeOfUsers);
            copyAccount.allRound = user.rounds;
            Console.WriteLine(copyAccount.GetStats());
        }
        public string GetName()
        {
            return "UserStats";
        }
        public string GetDescription() 
        {
            return "This command show all information about user";
        }
        public void ShowAllUsers()
        {

        }
        public void AddPlayerCommand()
        {

        }
        public void PlayGameCommand()
        {

        }
        public void GetHelp()
        {

        }
    }
}
