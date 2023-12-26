using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООП_ЛР__3_справжня.Services;

namespace ООП_ЛР__3_справжня
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBContext context = new DBContext();
            GameService gameService = new GameService(context);
            UserService userService = new UserService(context);
            userService.createAccount("Hercules", "Premium");
            userService.createAccount("Nemean Lion", "Base");
            userService.createAccount("Lernean Hydra", "Safe");
            gameService.CreateGame("Base", "Hercules", "Nemean Lion", userService);
            gameService.CreateGame("OnePlayerRisk", "Hercules", "Lernean Hydra", userService);
            gameService.CreateGame("Training", "Nemean Lion", "Lernean Hydra", userService);

            userService.showUserInfo("Hercules");
            userService.showUserInfo("Nemean Lion");
            userService.showUserInfo("Lernean Hydra");

            Console.WriteLine("\t\tData Base");
            Console.WriteLine("\tPlayers:");
            List <UsersEntity> allPlayers = userService.ReadAccounts();
            foreach(UsersEntity user in allPlayers)
            {
                Console.WriteLine("\t"+user.UserName);
                Console.WriteLine("Type of user: " + user.typeOfUsers);
                Console.WriteLine("Raiting: "+user.CurrentRaiting);
                Console.WriteLine("Count of games: "+user.GamesCount);
                Console.WriteLine("Count of winning games: "+user.countOfWinningGames);
                Console.WriteLine("Count of lost games: " + user.countOfLostGames);
            }
            Console.WriteLine("\nGames of Neman Lion");
            List <GamesEntity> gamesOfSecondPlayer = gameService.ReadPlayerGamesByPlayerName("Nemean Lion");
            foreach(GamesEntity gameForUser in gamesOfSecondPlayer)
            {
                Console.WriteLine("Game number " + gameForUser.ID);
                Console.WriteLine("Game type: "+ gameForUser.GameType);
                Console.WriteLine("Players of this game: ");
                foreach (UsersEntity players in gameForUser.players) 
                {
                    Console.WriteLine(players.UserName);
                }
                Console.WriteLine("Best player: " + gameForUser.BestPlayer.UserName);
            }
            Console.WriteLine("\nAll games:");
            List<GamesEntity> allGames = gameService.ReadGames();
            foreach(GamesEntity thisGame in allGames)
            {
                Console.WriteLine("Game number " + thisGame.ID);
                Console.WriteLine("Game type: " + thisGame.GameType);
                Console.WriteLine("Players of this game: ");
                foreach (UsersEntity players in thisGame.players)
                {
                    Console.WriteLine(players.UserName);
                }
                Console.WriteLine("Best player: " + thisGame.BestPlayer.UserName);
            }
            Console.ReadKey();
        }
    }
}
