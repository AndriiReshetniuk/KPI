using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООП_ЛР__3_справжня.Services;

namespace ООП_ЛР__3_справжня.Repositories
{
    internal class GamesCRUD : GamesRepository
    {
        private DBContext dataBase;
        public GamesCRUD(DBContext dataBase)
        {
            this.dataBase = dataBase;
        }
        public BaseGame Create(string ID, string GameType, List<UsersEntity> players, UsersEntity BestPlayer = null)
        {
           GamesEntity entity = new GamesEntity(ID, GameType, players, BestPlayer);
           dataBase.Games.Add(entity);
           GameFactory createGame = new GameFactory();
           var startGames = createGame.CreateGame(GameType);
            startGames.Number = ID;
           return startGames;
        }
        public List<GamesEntity> Read()
        {
            return dataBase.Games;
        }
        public void Update(long id, string GameType, List<UsersEntity> players, UsersEntity BestPlayer)
        {
            if (id >= 0 && id <= dataBase.Games.Count)
            {
                GamesEntity entity = new GamesEntity(id.ToString(), GameType, players, BestPlayer);
                dataBase.Games[(int)(id-1)] = entity;
            }
            else
            {
                Console.WriteLine("Неможливо оновити данi для гри з iдентифiкатором"+ id+ ", оскiльки гри з таки номером не iснує");
            }
        }
        public void Delete(GamesEntity entity)
        {
            dataBase.Games.Remove(entity);
        }
    }
}
