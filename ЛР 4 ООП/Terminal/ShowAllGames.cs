using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП.Terminal
{
    internal class ShowAllGames : CommandInterface
    {
        private GameService game_Service;
        public ShowAllGames(GameService game_Service)
        {
            this.game_Service = game_Service;
        }
        public void Execute()
        {
            printAllGames();
        }
        public void printAllGames()
        {
            List<GamesEntity> allGames = game_Service.ReadGames();
            foreach(GamesEntity game in allGames)
            {
                Console.WriteLine("Game id: "+ game.ID);
                Console.WriteLine("Game type: " + game.GameType);
                Console.WriteLine("Players of game:");
                foreach(UsersEntity player in game.players)
                {
                    Console.WriteLine(player.UserName);
                }
                Console.WriteLine("Best PLayer is: " + game.BestPlayer.UserName);
            }
        }
        public void ShowAllUsers()
        {
        }
        public string GetName()
        {
            return "ShowAllGames";
        }
        public string GetDescription()
        {
            return "This command show all games";
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
