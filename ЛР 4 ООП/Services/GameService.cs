using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;
using ЛР_4_ООП;
using ЛР_4_ООП.Repositories;

namespace ЛР_4_ООП.Services
{
    public class GameService : IGameService
    {
        public GamesRepository repository { get; set; }
        AccountFactory factory;
        public GameService(DBContext context)
        {
            repository = new GamesCRUD(context);
            factory = new AccountFactory();
        }
        public List<GamesEntity> ReadGames()
        {
            return repository.Read();
        }
        public List<GamesEntity> ReadPlayerGamesByPlayerName(string playerName)
        {
            List<GamesEntity> AllGames = repository.Read();
            List<GamesEntity> PlayerGames = new List<GamesEntity>();
            for (int i = 0; i < AllGames.Count; i++)
            {
                for (int j = 0; j < AllGames[i].players.Count; j++)
                {
                    if (AllGames[i].players[j].UserName == playerName)
                    {
                        PlayerGames.Add(AllGames[i]);
                        break;
                    }
                }
            }
            return PlayerGames;
        }
        public void CreateGame(string GameType, string firstPlayerName, string secondPlayerName, UserService userService, UsersEntity BestPlayer = null)
        {
            List<GamesEntity> allGames = repository.Read();
            long IDSeed = Convert.ToInt64(allGames[allGames.Count - 1].ID);
            IDSeed++;
            string ID = IDSeed.ToString();
            List<UsersEntity> playersInGame = new List<UsersEntity>();
            playersInGame.Add(userService.ReadAccountByName(firstPlayerName));
            playersInGame.Add(userService.ReadAccountByName(secondPlayerName));
            var game = repository.Create(ID, GameType, playersInGame, BestPlayer);
            var firstGladiator = factory.CreateAccount(playersInGame[0].UserName, playersInGame[0].typeOfUsers);
            var secondGladiator = factory.CreateAccount(playersInGame[1].UserName, playersInGame[1].typeOfUsers);
            game.startGame(firstGladiator, secondGladiator, playersInGame, this, "Base", userService);
        }
        public void UpdateGame(long id, string GameType, List<UsersEntity> players, UsersEntity BestPlayer)
        {
            repository.Update(id, GameType, players, BestPlayer);
        }
    }
}
