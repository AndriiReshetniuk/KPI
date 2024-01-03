using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП.Terminal
{
    public class ShowGameOfUsers : CommandInterface
    {
        private GameService service;
        public ShowGameOfUsers(GameService service)
        {
            this.service = service;
        }
        public void Execute()
        {
            ShowGameOfPlayer();
        }
        public void ShowGameOfPlayer()
        {
            Console.WriteLine("Write the name of player");
            string playerName = Console.ReadLine();
            List<GamesEntity> gamesOfPlayer = service.ReadPlayerGamesByPlayerName(playerName);
            if (gamesOfPlayer.Count > 0)
            {
                Console.WriteLine("Games of "+ playerName);
                foreach (GamesEntity game in gamesOfPlayer)
                {
                    Console.WriteLine("Game id: "+ game.ID);
                    Console.WriteLine("The type of game: "+game.GameType);
                    Console.WriteLine("Players: ");
                    foreach(UsersEntity player in game.players)
                    {
                        Console.WriteLine(player.UserName);
                    }
                    Console.WriteLine("The best player is: "+game.BestPlayer.UserName);
                }
            }
            else
            {
                Console.WriteLine($"Player with name {playerName} didn't take part in the games");
            }
        }
        public void ShowAllUsers()
        {
        }
        public string GetName()
        {
            return "ShowGameOfUser";
        }
        public string GetDescription()
        {
            return "This command show all games of user";
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
    }
}
