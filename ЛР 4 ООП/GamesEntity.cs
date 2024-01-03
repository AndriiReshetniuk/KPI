using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_4_ООП
{
    public class GamesEntity
    {
        public UsersEntity BestPlayer;
        public string ID;
        public string GameType;
        public List<UsersEntity> players;
        public GamesEntity(string ID, string GameType, List<UsersEntity> players = null, UsersEntity BestPlayer = null)
        {
            this.ID = ID;
            this.GameType = GameType;
            this.BestPlayer = BestPlayer;
            if (players != null)
            {
                this.players = copyList(players);
            }
            else
            {
                this.players = players;
            }
        }
        public GamesEntity SetGamesEntity(string ID, string GameType, List<UsersEntity> players, UsersEntity BestPlayer = null)
        {
            GamesEntity entity = new GamesEntity(ID, GameType, players, BestPlayer);
            return entity;
        }
        public List<UsersEntity> copyList(List<UsersEntity> copyFrom)
        {
            List<UsersEntity> result = new List<UsersEntity>();
            foreach (UsersEntity copy in copyFrom)
            {
                UsersEntity copyTo = new UsersEntity(copy.UserName, copy.typeOfUsers);
                copyTo.CurrentRaiting = copy.CurrentRaiting;
                copyTo.GamesCount = copy.GamesCount;
                copyTo.countOfWinningGames = copy.countOfWinningGames;
                copyTo.countOfLostGames = copy.countOfLostGames;
                copyTo.rounds = copy.rounds;
                result.Add(copyTo);
            }
            return result;
        }
    }
}
