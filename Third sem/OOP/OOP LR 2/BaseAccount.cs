using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR_2
{
   public class BaseAccount
    {
        protected long game_index_seed = 1;
        public string UserName;
        public long CurrentRaiting
        {
            get
            {
                long totalRaiting = 1;
                foreach (var item in allRound)
                {
                    if (totalRaiting + item.Raiting < 1)
                    {
                        totalRaiting = 1;
                    }
                    else
                    {
                        totalRaiting += item.Raiting;
                    }
                }
                return totalRaiting;
            }

        }
        public long GamesCount
        {
            get
            {
                return allRound.Count;
            }
        }
        public virtual void WinGame(string oponentName, BaseGame game)
        {
            long Raiting = game.GetRaiting();
            if (Raiting < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Raiting), "You can not put a negative bet");
            }
            Round win = new Round(oponentName, Raiting, "Win", game_index_seed);
            game_index_seed++;
            allRound.Add(win);
        }
        public virtual void LoseGame(string oponentName, BaseGame game)
        {
            long Raiting = game.GetRaiting();
            if (Raiting < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Raiting), "You can not put a negative bet");
            }
            Round lose = new Round(oponentName, -Raiting, "Lose", game_index_seed);
            game_index_seed++;
            allRound.Add(lose);
        }
        public string GetStats()
        {
            var stats = new StringBuilder();
            stats.AppendLine("Opponent\tresult\tRaiting\t\tGame index");
            foreach (var item in allRound)
            {
                stats.AppendLine($"{item.opponentName}\t{item.resultGame}\t{item.Raiting}\t\t{item.gameIndex}");
            }
            return stats.ToString();
        }
        public BaseAccount(string UserName)
        {
            this.UserName = UserName;
        }
        protected List<Round> allRound = new List<Round>();
    }
}

