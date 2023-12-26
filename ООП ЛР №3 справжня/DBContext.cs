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
                new UsersEntity("Borei", "Premium")
                {
                    CurrentRaiting = 10,
                    GamesCount = 4,
                    countOfLostGames = 1,
                    countOfWinningGames = 3
                },
                new UsersEntity("Poseidon", "Safe")
                {
                    CurrentRaiting = 28,
                    GamesCount = 3,
                    countOfLostGames = 2,
                    countOfWinningGames = 1
                },
                new UsersEntity("Aid", "Base")
                {
                    CurrentRaiting = 32,  
                    GamesCount = 7,
                    countOfLostGames = 5,
                    countOfWinningGames = 2
                },
                new UsersEntity("Zevs", "Premium")
                {
                    CurrentRaiting = 8,
                    GamesCount = 4,
                    countOfLostGames = 3,
                    countOfWinningGames = 1
                }
            };
            Games = new List<GamesEntity>()
            {
                new GamesEntity("1", "Base")
                {
                    BestPlayer = Users[1],
                    players = new List<UsersEntity>()
                    {
                        Users[1],
                        Users[0]
                    }
                },
                new GamesEntity("2", "Training")
                {
                    BestPlayer = Users[3],
                    players = new List<UsersEntity>()
                    {
                        Users[3],
                        Users[2]
                    }
                },
                new GamesEntity("3", "OnePlayerRisk")
                {
                    BestPlayer = Users[2],
                    players = new List<UsersEntity>()
                    {
                        Users[2],
                        Users[1]
                    }
                },
                new GamesEntity("4", "Base")
                {
                    BestPlayer = Users[0],
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
