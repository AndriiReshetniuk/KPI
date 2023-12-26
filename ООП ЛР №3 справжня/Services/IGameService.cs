using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООП_ЛР__3_справжня.Repositories;

namespace ООП_ЛР__3_справжня.Services
{
    public interface IGameService
    {
        public GamesRepository repository { get; set; }
        public List<GamesEntity> ReadGames();
        public List<GamesEntity> ReadPlayerGamesByPlayerName(string playerName);
        public void CreateGame(string GameType, string firstPlayerName, string secondPlayerName, UserService userService, UsersEntity BestPlayer = null);
        public void UpdateGame(long id, string GameType, List<UsersEntity> players, UsersEntity BestPlayer);
    }
}
