using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня
{
    public class DBContext
    {
        public List<UsersEntity> Users;
        public List<GamesEntity> Games;
        public DBContext()
        {
            Users = new List<UsersEntity>()
            {
                new UsersEntity()
                {
                    UserName = "Borei",
                    typeOfUsers = "Premium",
                    CurrentRaiting = 10,
                    GamesCount = 4,
                    countOfLostGames = 1,
                    countOfWinningGames = 3
                },
                new UsersEntity()
                {
                    UserName = "Poseidon",
                    typeOfUsers = "Safe",
                    CurrentRaiting = 28,
                    GamesCount = 3,
                    countOfLostGames = 2,
                    countOfWinningGames = 1
                },
                new UsersEntity()
                {
                    UserName = "Aid",
                    typeOfUsers = "Base",
                    CurrentRaiting = 32,
                    GamesCount = 7,
                    countOfLostGames = 5,
                    countOfWinningGames = 2
                },
                new UsersEntity()
                {
                    UserName = "Zevs",
                    typeOfUsers = "Premium",
                    CurrentRaiting = 8,
                    GamesCount = 4,
                    countOfLostGames = 3,
                    countOfWinningGames = 1
                }
            };
            Games = new List<GamesEntity>()
            {
                new GamesEntity()
                {
                    BestPlayer = Users[1],
                    ID = "1",
                    GameType = "Base",
                    players = new List<UsersEntity>()
                    {
                        Users[1],
                        Users[0]
                    }
                },
                new GamesEntity()
                {
                    BestPlayer = Users[3],
                    ID = "2",
                    GameType = "Training",
                    players = new List<UsersEntity>()
                    {
                        Users[3],
                        Users[2]
                    }
                },
                new GamesEntity()
                {
                    BestPlayer = Users[2],
                    ID = "3",
                    GameType = "OnePlayerRisk",
                    players = new List<UsersEntity>()
                    {
                        Users[2],
                        Users[1]
                    }
                },
                new GamesEntity()
                {
                    BestPlayer = Users[0],
                    ID = "4",
                    GameType = "Base",
                    players = new List<UsersEntity>()
                    {
                         Users[0],
                         Users[3],
                    }
                }
            };
        }
    }
}
