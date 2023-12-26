using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Repositories;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП.Terminal
{
    public class PlayGame : CommandInterface
    {
        private GameService game_service;
        private UserService user_service;
        private List<string> typesOfGames;
        public PlayGame(GameService gService, UserService uService) 
        {
            this.game_service = gService;
            this.user_service = uService;
            typesOfGames = new List<string>();
            typesOfGames.Add("Base");
            typesOfGames.Add("OnePlayerRisk");
            typesOfGames.Add("Training");
        }
        public void Execute()
        {
            PlayGameCommand();
        }
        public void PlayGameCommand()
        {
            Console.WriteLine("Allows Type of Game");
            foreach(string type in typesOfGames)
            {
                Console.WriteLine(type);
            }
            bool chooseIsCorrect = false;
            string choosenType;
            do
            {
                Console.WriteLine("Choose type of your game: ");
                choosenType = Console.ReadLine();
                for (int i = 0; i < typesOfGames.Count; i++)
                {
                    if (choosenType == typesOfGames[i])
                    {
                        chooseIsCorrect = true;
                    }
                }
            } while (!chooseIsCorrect);
            string firstPlayerName;
            string secondPlayerName;
            do
            {
                Console.WriteLine("Write name of first player");
                firstPlayerName = Console.ReadLine();
            } while (user_service.ReadAccountByName(firstPlayerName) == null);
            do
            {
                Console.WriteLine("Write name of second player");
                secondPlayerName = Console.ReadLine();
            } while (user_service.ReadAccountByName(secondPlayerName) == null);
            game_service.CreateGame(choosenType, firstPlayerName, secondPlayerName, user_service);
        }
        public string GetName()
        {
            return "PlayGame";
        }
        public string GetDescription() 
        {
            return "This command can create a new game";
        }
        public void ShowAllUsers()
        {

        }
        public void AddPlayerCommand()
        {

        }
        public void ShowPlayerStats()
        {

        }
        public void GetHelp()
        {

        }
    }
}
