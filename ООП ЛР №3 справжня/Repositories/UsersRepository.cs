using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня.Repositories
{
    public interface UsersRepository
    {
        public UsersEntity Create(string UserName, string typeOfUsers);
        public List<UsersEntity> Read();
        public void Update(string UserName, string typeOfUsers, UsersEntity entity, long Rait = 0, string opponentName = "", long GamesCount = 0, long countOfWinningGames = 0, long countOfLostGames = 0);
        public void Delete(UsersEntity entity);
    }
}
