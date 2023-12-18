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
            GameFactory createGame = new GameFactory();
            List<UsersEntity> playersInGame = new List<UsersEntity>();
            PremiumAccount firstGladiator = new PremiumAccount("Hercules");
            
            UsersEntity firstUserEntity = new UsersEntity();
            firstUserEntity = firstUserEntity.SetUsersEntity("Hercules", "Premium");
            userService.createAccount(firstUserEntity);
            playersInGame.Add(firstUserEntity);

            BaseAccount secondGladiator = new BaseAccount("Nemean Lion");

            UsersEntity secondUserEntity = new UsersEntity();
            secondUserEntity = secondUserEntity.SetUsersEntity("Nemean Lion", "Base");
            userService.createAccount(secondUserEntity);
            playersInGame.Add(secondUserEntity);

            var Game = createGame.CreateGame("Base");
            Game.startGame(firstGladiator, secondGladiator, playersInGame, gameService, "Base", userService);
            playersInGame.Clear();

            Game = createGame.CreateGame("OnePlayer");
            safeAccount thirdGladiator = new safeAccount("Lernean Hydra");

            UsersEntity thirdUserEntity = new UsersEntity();
            thirdUserEntity = thirdUserEntity.SetUsersEntity("Lernean Hydra", "Safe");
            userService.createAccount(thirdUserEntity);
           
            playersInGame.Add(firstUserEntity);
            playersInGame.Add(thirdUserEntity);
            Game.startGame(firstGladiator, thirdGladiator, playersInGame, gameService, "OnePlayerRisk", userService);
            playersInGame.Clear();

            playersInGame.Add(secondUserEntity);
            playersInGame.Add(thirdUserEntity);
            Game = createGame.CreateGame("Training");
            Game.startGame(secondGladiator, thirdGladiator, playersInGame, gameService, "Training", userService);
            playersInGame.Clear();


            Console.WriteLine("User name:" + firstGladiator.UserName);
            Console.WriteLine("Curent Raiting: " + firstGladiator.CurrentRaiting);
            Console.WriteLine("Games count: " + firstGladiator.GamesCount);
            Console.WriteLine("History:\n" + firstGladiator.GetStats());

            Console.WriteLine("User name: " + secondGladiator.UserName);
            Console.WriteLine("Curent Raiting: " + secondGladiator.CurrentRaiting);
            Console.WriteLine("Games count: " + secondGladiator.GamesCount);
            Console.WriteLine("History:\n" + secondGladiator.GetStats());

            Console.WriteLine("User name: " + thirdGladiator.UserName);
            Console.WriteLine("Curent Raiting: " + thirdGladiator.CurrentRaiting);
            Console.WriteLine("Games count: " + thirdGladiator.GamesCount);
            Console.WriteLine("History:\n" + thirdGladiator.GetStats());

            Console.WriteLine("\t\tData Base:\n\tPlayers:");
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
            Console.WriteLine("\nGames of "+ secondUserEntity.UserName);
            List <GamesEntity> gamesOfSecondPlayer = gameService.ReadPlayerGamesByPlayerName(secondUserEntity.UserName);
            foreach(GamesEntity gameForUser in gamesOfSecondPlayer)
            {
                Console.WriteLine("Game number " + gameForUser.ID);
                Console.WriteLine("Game type: "+ gameForUser.GameType);
                Console.WriteLine("Players of this game: ");
                foreach (UsersEntity players in gameForUser.players) 
                {
                    Console.WriteLine(players.UserName);
                }
                Console.WriteLine("Best player " + gameForUser.BestPlayer.UserName);

            }
            Console.WriteLine("\nAll games:");
            List<GamesEntity> allGames = gameService.ReadGames();
            foreach(GamesEntity game in allGames)
            {
                Console.WriteLine("Game number " + game.ID);
                Console.WriteLine("Game type: " + game.GameType);
                Console.WriteLine("Players of this game: ");
                foreach (UsersEntity players in game.players)
                {
                    Console.WriteLine(players.UserName);
                }
                Console.WriteLine("Best player: " + game.BestPlayer.UserName);
            }
            Console.ReadKey();
        }
    }
}
