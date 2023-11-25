using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR_2
{
    public class TrainingGame : BaseGame
    {
        protected override void ChooseRaitingBet(BaseAccount firstPlayer, BaseAccount secondPlayer)
        {
            Rait = 0;
        }
        protected override ReturnRaiting PlayerWin(BaseAccount Winner, BaseAccount Loser, long winnerEarnedRaiting, long loserEarnedRaiting)
        {
            Console.WriteLine($"Congratulations! {Winner.UserName} is a winner");
            Winner.WinGame(Loser.UserName, this);
            Loser.LoseGame(Winner.UserName, this);
            ReturnRaiting rRait = new ReturnRaiting(winnerEarnedRaiting, loserEarnedRaiting);
            return rRait;
        }
    }
}
