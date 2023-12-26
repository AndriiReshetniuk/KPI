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
        public List<Round> rounds;

        public UsersEntity(string UserName, string typeOfUsers) 
        {
            this.UserName = UserName;
            this.CurrentRaiting = 1;
            this.GamesCount = 0;
            this.countOfWinningGames = 0;
            this.countOfLostGames = 0;
            this.typeOfUsers = typeOfUsers;
            rounds = new List<Round>();
        }
        public void SetUsersEntity(string UserName, string opponentName, string typeOfUsers, long Rait, long GamesCount = 0, long countOfWinningGames = 0, long countOfLostGames = 0)
        {
            this.UserName = UserName;
            if (this.CurrentRaiting + Rait < 1)
            {
                this.CurrentRaiting = 1;
            }
            else
            {
                this.CurrentRaiting = this.CurrentRaiting + Rait;
            }
            if (this.GamesCount != GamesCount)
            {
                string GameResult;
                if (this.countOfWinningGames < countOfWinningGames)
                {
                    GameResult = "Win";
                }
                else
                {
                    GameResult = "Lose";
                }
                rounds.Add(new Round(opponentName, Rait, GameResult, GamesCount));
            }
            this.GamesCount = GamesCount;
            this.countOfWinningGames = countOfWinningGames;
            this.countOfLostGames = countOfLostGames;
            this.typeOfUsers = typeOfUsers;
        }
    }
}
