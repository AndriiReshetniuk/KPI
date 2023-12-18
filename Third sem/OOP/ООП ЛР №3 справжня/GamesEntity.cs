using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня
{
    public class GamesEntity
    {
        public UsersEntity BestPlayer;
        public string ID;
        public string GameType;
        public List<UsersEntity> players;

        public GamesEntity SetGamesEntity(string ID, string GameType, List<UsersEntity> players, UsersEntity BestPlayer = null)
        {
            GamesEntity entity = new GamesEntity();
            entity.BestPlayer = BestPlayer;
            entity.ID = ID;
            entity.GameType = GameType;
            entity.players = copyList(players);
            return entity;
        }
        public List <UsersEntity> copyList(List<UsersEntity> copyFrom) 
        {
            List <UsersEntity> result = new List <UsersEntity>();
            foreach (UsersEntity copy in copyFrom)
            {
                UsersEntity copyTo = new UsersEntity();
                copyTo = copyTo.SetUsersEntity(copy.UserName, copy.typeOfUsers, copy.CurrentRaiting, copy.GamesCount, copy.countOfWinningGames, copy.countOfLostGames);
                result.Add(copyTo);
            }
            return result;
        }
    }
}
