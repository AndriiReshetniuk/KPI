using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR_2
{
    public class OnePLayerRiskGame: BaseGame
    {
        private string RiskPlayer;
        private void ChooseRiskPlayer(BaseAccount firstPlayer, BaseAccount secondPlayer)
        {
            Console.WriteLine("Choose player which will be play for raiting");
            do
            {
                Console.WriteLine("1 - " + firstPlayer.UserName + "\n2-" + secondPlayer.UserName);
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 1)
                {
                    RiskPlayer = firstPlayer.UserName;
                    return;
                }
                else if (choose == 2)
                {
                    RiskPlayer = secondPlayer.UserName;
                    return;
                }
                else
                {
                    Console.WriteLine("Гравця з таким номером не існує");
                }
            }while(true);
        }
        protected override void ChooseRaitingBet(BaseAccount firstPlayer, BaseAccount secondPlayer)
        {
            ChooseRiskPlayer(firstPlayer, secondPlayer);
            Console.WriteLine("Choose a rating rate:");
            Rait = 0;
            bool setRaiting = false;
            do
            {
                try
                {
                    Rait = Convert.ToInt64(Console.ReadLine());
                    if (Rait < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(Rait), "You can not put a negative bet");
                    }
                    else
                    {
                        setRaiting = true;
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Exeption was caught");
                    Console.WriteLine(e.Message);
                }
            } while (!setRaiting);
        }
        protected override ReturnRaiting PlayerWin(BaseAccount Winner, BaseAccount Loser, long winnerEarnedRaiting, long loserEarnedRaiting)
        {
            Console.WriteLine($"Congratulations! {Winner.UserName} is a winner"); // змінити так щоб ризикував лише один гравець.
            if(RiskPlayer == Winner.UserName)
            {
                Winner.WinGame(Loser.UserName, this);
                winnerEarnedRaiting += Rait;
                Rait = 0;
                Loser.LoseGame(Winner.UserName, this);        
            }
            else
            {        
                Loser.LoseGame(Winner.UserName, this);
                if (loserEarnedRaiting - Rait < 1)
                {
                    loserEarnedRaiting = 1;
                }
                else
                {
                    loserEarnedRaiting -= Rait;
                }

                Rait = 0;
                Winner.WinGame(Loser.UserName, this);
            }  
            ReturnRaiting rRait = new ReturnRaiting(winnerEarnedRaiting, loserEarnedRaiting);
            return rRait;
        }
    }
}
