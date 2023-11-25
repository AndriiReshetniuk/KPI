using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR_2
{

    public abstract class BaseGame
    {
        private static long Game_number_seed = 0;
        public BaseAccount BestPlayer;
        protected long Rait;
        public string Number { get { return Game_number_seed.ToString(); } }
        protected abstract void ChooseRaitingBet(BaseAccount firstPlayer, BaseAccount secondPlayer);
        protected virtual ReturnRaiting PlayerWin(BaseAccount Winner, BaseAccount Loser, long winnerEarnedRaiting, long loserEarnedRaiting)
        {
            Console.WriteLine($"Congratulations! {Winner.UserName} is a winner");
            Winner.WinGame(Loser.UserName, this);
            Loser.LoseGame(Winner.UserName, this);
            winnerEarnedRaiting += Rait;
            if (loserEarnedRaiting - Rait < 1)
            {
                loserEarnedRaiting = 1;
            }
            else
            {
                loserEarnedRaiting -= Rait;
            }
            ReturnRaiting rRait = new ReturnRaiting(winnerEarnedRaiting, loserEarnedRaiting);
            return rRait;
        }
        public long GetRaiting()
        {
            return Rait;
        }
        public void startGame(BaseAccount firstPlayer, BaseAccount SecondPlayer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tGame number " + Number);
            Console.ResetColor();
            Console.WriteLine("Hello players! You have to press on \"plus\" for win");
            string reply = "-";
            long first_player_earned_raiting = 1;
            long second_player_earned_raiting = 1;
            do
            {
                Rait = 0;
                ChooseRaitingBet(firstPlayer, SecondPlayer);
                string symbol = "-";
                do
                {
                    Console.WriteLine(firstPlayer.UserName + ", your move:");
                    symbol = Convert.ToString(Console.ReadLine());
                    if (symbol == "+")
                    {
                        ReturnRaiting copyInfo;
                        copyInfo = PlayerWin(firstPlayer, SecondPlayer, first_player_earned_raiting, second_player_earned_raiting);
                        first_player_earned_raiting = copyInfo.WinnerEarnedRaiting;
                        second_player_earned_raiting = copyInfo.LoserEarnedRaiting;
                    }
                    else
                    {
                        Console.WriteLine(SecondPlayer.UserName + ", your move:");
                        symbol = Convert.ToString(Console.ReadLine());
                        if (symbol == "+")
                        {
                            ReturnRaiting copyInfo;
                            copyInfo = PlayerWin(SecondPlayer, firstPlayer, second_player_earned_raiting, first_player_earned_raiting);
                            second_player_earned_raiting = copyInfo.WinnerEarnedRaiting;
                            first_player_earned_raiting = copyInfo.LoserEarnedRaiting;
                        }
                    }
                } while (symbol != "+");
                Console.WriteLine("Press \"plus\" if you want to continue:");
                reply = Convert.ToString(Console.ReadLine());
            } while (reply == "+");
            if (first_player_earned_raiting > second_player_earned_raiting)
            {
                BestPlayer = firstPlayer;
            }
            else if (second_player_earned_raiting > first_player_earned_raiting)
            {
                BestPlayer = SecondPlayer;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Game number " + Number + ":");
                Console.WriteLine("Жоден гравець не здобув переваги у рейтингу");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Game number " + Number + ":");
            Console.WriteLine("The best player is " + BestPlayer.UserName);
            if (first_player_earned_raiting > second_player_earned_raiting)
            {
                Console.WriteLine("Raiting in this game without bonus: " + first_player_earned_raiting);
            }
            else if (second_player_earned_raiting > first_player_earned_raiting)
            {
                Console.WriteLine("Raiting in this game without bonus: " + second_player_earned_raiting);
            }
            Console.WriteLine("Total raiting " + BestPlayer.CurrentRaiting + "\n\n");
            Console.ResetColor();
        }
        public BaseGame()
        {
            Game_number_seed++;
        }
    }
}
