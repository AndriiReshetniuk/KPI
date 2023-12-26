using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП.Repositories
{
    internal class UsersCRUD : UsersRepository
    {
        private DBContext dataBase;
        public UsersCRUD(DBContext dataBase)
        {
            this.dataBase = dataBase;
        }
        public UsersEntity Create(string UserName, string typeOfUsers)
        {
            UsersEntity entity = new UsersEntity(UserName, typeOfUsers);
            dataBase.Users.Add(entity);
            return entity;
        }
        public List<UsersEntity> Read()
        {
            return dataBase.Users;
        }
        public void Update(string UserName, string typeOfUsers, UsersEntity entity, long Rait = 0, string opponentName = "", long GamesCount = 0, long countOfWinningGames = 0, long countOfLostGames = 0)
        {
            for (int i = 0; i < dataBase.Users.Count; i++)
            {
                if (dataBase.Users[i].UserName == UserName)
                {
                    entity.SetUsersEntity(UserName, opponentName, typeOfUsers, Rait, GamesCount, countOfWinningGames, countOfLostGames);
                    dataBase.Users[i] = entity;
                }
            }
        }
        public void Delete(UsersEntity entity)
        {
            dataBase.Users.Remove(entity);
        }
    }
}
