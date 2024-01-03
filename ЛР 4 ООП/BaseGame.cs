using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;

namespace ЛР_4_ООП
{

    public abstract class BaseGame
    {
        public BaseAccount BestPlayer;
        protected long Rait;
        public string Number;
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
        protected virtual void UpdateInfo(UsersEntity WinnerPlayer, UsersEntity LoserPlayer, UserService userService)
        {
            int accountCoef = 1;
            if (WinnerPlayer.typeOfUsers == "Premium")
            {
                accountCoef = 2;
            }
            userService.UpdateAccountInfo(WinnerPlayer.UserName, WinnerPlayer.typeOfUsers, WinnerPlayer, Rait * accountCoef, LoserPlayer.UserName, WinnerPlayer.GamesCount + 1, WinnerPlayer.countOfWinningGames + 1, WinnerPlayer.countOfLostGames);
            accountCoef = 1;
            if (LoserPlayer.typeOfUsers == "Safe")
            {
                accountCoef = 2;
            }
            userService.UpdateAccountInfo(LoserPlayer.UserName, LoserPlayer.typeOfUsers, LoserPlayer, (-Rait / accountCoef), WinnerPlayer.UserName, LoserPlayer.GamesCount + 1, LoserPlayer.countOfWinningGames, LoserPlayer.countOfLostGames + 1);
        }
        public void startGame(BaseAccount firstPlayer, BaseAccount SecondPlayer, List<UsersEntity> players, GameService gameService, string Type, UserService userService)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tGame number " + Number);
            Console.ResetColor();
            Console.WriteLine("Hello players! You have to press on \"plus\" for win");
            string reply = "-";
            long first_player_earned_raiting = 1;
            long second_player_earned_raiting = 1;

            for (int i = 0; i < players.Count(); i++)
            {
                players[i] = userService.ReadAccountByName(players[i].UserName);
            }
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
                        UpdateInfo(players[0], players[1], userService);
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
                            UpdateInfo(players[1], players[0], userService);
                        }
                    }
                } while (symbol != "+");
                for (int i = 0; i < players.Count(); i++)
                {
                    players[i] = userService.ReadAccountByName(players[i].UserName);
                }
                Console.WriteLine("Press \"plus\" if you want to continue:");
                reply = Convert.ToString(Console.ReadLine());
            } while (reply == "+");
            if (first_player_earned_raiting > second_player_earned_raiting)
            {
                BestPlayer = firstPlayer;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Game number " + Number + ":");
                Console.WriteLine("The best player is " + BestPlayer.UserName);
            }
            else if (second_player_earned_raiting > first_player_earned_raiting)
            {
                BestPlayer = SecondPlayer;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Game number " + Number + ":");
                Console.WriteLine("The best player is " + BestPlayer.UserName);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Game number " + Number + ":");
                Console.WriteLine("The best player doesn't exist");
                Console.ResetColor();
                BaseAccount none = new BaseAccount("The best player doesn't exist");
                BestPlayer = none;
            }
            if (first_player_earned_raiting > second_player_earned_raiting)
            {
                Console.WriteLine("Raiting in this game without bonus: " + first_player_earned_raiting);
                Console.WriteLine("Total raiting " + BestPlayer.CurrentRaiting + "\n\n");
            }
            else if (second_player_earned_raiting > first_player_earned_raiting)
            {
                Console.WriteLine("Raiting in this game without bonus: " + second_player_earned_raiting);
                Console.WriteLine("Total raiting " + BestPlayer.CurrentRaiting + "\n\n");
            }
            Console.ResetColor();
            UsersEntity bestUser = null;
            if (BestPlayer.UserName != "The best player doesn't exist")
            {
                bestUser = userService.ReadAccountByName(BestPlayer.UserName);
            }
            else
            {
                bestUser = new UsersEntity(BestPlayer.UserName, "None");
            }
            long id = Convert.ToInt64(Number);
            gameService.UpdateGame(id, Type, players, bestUser);
        }
    }
}
