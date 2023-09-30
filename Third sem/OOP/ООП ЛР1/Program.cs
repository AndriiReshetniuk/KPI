
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР1
{
    
   

    

    internal class Program
    {
        static void Main(string[] args)
        {
            GameAccount firstGladiator = new GameAccount("Hercules");
            GameAccount secondGladiator = new GameAccount("Nemean Lion");
            Game firstGame = new Game();
            firstGame.startGame(firstGladiator, secondGladiator);
           
            Game secondGame = new Game();
            GameAccount thirdGladiator = new GameAccount("Lernean Hydra");
            secondGame.startGame(firstGladiator, thirdGladiator);
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
