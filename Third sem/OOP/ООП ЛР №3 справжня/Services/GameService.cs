using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООП_ЛР__3_справжня.Repositories;

namespace ООП_ЛР__3_справжня.Services
{
    public class GameService : IGameService
    {
        public GamesRepository repository { get; set; }
        public GameService(DBContext context)
        {
            repository = new GamesCRUD(context);
        }
        public List<GamesEntity> ReadGames()
        {
            return repository.Read();
        }
        public List<GamesEntity> ReadPlayerGamesByPlayerName(string playerName)
        {
           List<GamesEntity> AllGames = repository.Read();
            List<GamesEntity> PlayerGames = new List<GamesEntity>();
           for(int i = 0; i < AllGames.Count; i++) 
           {
                for(int j = 0; j < AllGames[i].players.Count; j++)
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
        public void CreateGame(GamesEntity entity)
        {
            repository.Create(entity);
        }
    } 
}
