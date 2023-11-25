using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameFactory createGame = new GameFactory();
            PremiumAccount firstGladiator = new PremiumAccount("Hercules");
            BaseAccount secondGladiator = new BaseAccount("Nemean Lion");
            var Game = createGame.CreateGame("Base");
            Game.startGame(firstGladiator, secondGladiator);

            Game = createGame.CreateGame("OnePlayer");
            safeAccount thirdGladiator = new safeAccount("Lernean Hydra");
            Game.startGame(firstGladiator, thirdGladiator);

            Game = createGame.CreateGame("Training");
            Game.startGame(secondGladiator, thirdGladiator);
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
            Console.ReadKey();
        }
    }

}

