using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня
{
    public class UsersEntity
    {
        public string UserName;
        public long CurrentRaiting;
        public long GamesCount;
        public long countOfWinningGames;
        public long countOfLostGames;
        public string typeOfUsers;

        public UsersEntity SetUsersEntity(string UserName, string typeOfUsers, long CurrentRaiting = 1, long GamesCount = 0, long countOfWinningGames = 0, long countOfLostGames = 0)
        {
            UsersEntity entity = new UsersEntity();
            entity.UserName = UserName;
            if(CurrentRaiting < 1)
            {
                CurrentRaiting = 1;
            }
            entity.CurrentRaiting = CurrentRaiting;
            entity.GamesCount = GamesCount;
            entity.countOfWinningGames = countOfWinningGames;
            entity.countOfLostGames = countOfLostGames;
            entity.typeOfUsers = typeOfUsers;
            return entity;
        }
    }
}
