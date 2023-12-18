using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня
{
    public class safeAccount : BaseAccount
    {
        public safeAccount(string UserName) : base(UserName)
        {
        }
        public override void LoseGame(string oponentName, BaseGame game)
        {
            long Raiting = game.GetRaiting();
            if (Raiting < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Raiting), "You can not put a negative bet");
            }
            Round lose = new Round(oponentName, -Raiting / 2, "Lose", game_index_seed);
            game_index_seed++;
            allRound.Add(lose);
        }
    }
}
