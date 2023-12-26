using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;
using ЛР_4_ООП.Repositories;

namespace ЛР_4_ООП.Services
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
