using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня
{
    public class PremiumAccount : BaseAccount
    {
        public PremiumAccount(string UserName) : base(UserName)
        {

        }
        public override void WinGame(string oponentName, BaseGame game)
        {
            long Raiting = game.GetRaiting();
            if (Raiting < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Raiting), "You can not put a negative bet");
            }
            Round win = new Round(oponentName, Raiting * 2, "Win", game_index_seed);
            game_index_seed++;
            allRound.Add(win);
        }
    }
}

