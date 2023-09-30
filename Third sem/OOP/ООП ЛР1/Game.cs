using System;

namespace ООП_ЛР1
{
    public class Game
    {
        private static long Game_number_seed = 1;
        public GameAccount BestPlayer;
        public string Number { get { return Game_number_seed.ToString(); } }
        public void startGame(GameAccount firstPlayer, GameAccount SecondPlayer)
        {
            Console.WriteLine("Hello players! You have to press on \"plus\" for win");
            string reply = "-";
            long first_player_earned_raiting = 1;
            long second_player_earned_raiting = 1;
            do
            {
                long Raiting = 0;
                bool setRaiting = false;
                Console.WriteLine("Choose a rating rate:");
                do
                {
                    try
                    {
                        Raiting = Convert.ToInt64(Console.ReadLine());
                        if (Raiting < 0)
                        {
                            throw new ArgumentOutOfRangeException(nameof(Raiting), "You can not put a negative bet");
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

                string symbol = "-";
                do
                {
                    Console.WriteLine(firstPlayer.UserName + ", your move:");
                    symbol = Convert.ToString(Console.ReadLine());
                    if (symbol == "+")
                    {
                        Console.WriteLine($"Congratulations! {firstPlayer.UserName} is a winner");
                        firstPlayer.WinGame(SecondPlayer.UserName, Raiting);
                        SecondPlayer.LoseGame(firstPlayer.UserName, Raiting);
                        first_player_earned_raiting += Raiting;
                        if (second_player_earned_raiting - Raiting < 1)
                        {
                            second_player_earned_raiting = 1;
                        }
                        else
                        {
                            second_player_earned_raiting -= Raiting;
                        }

                    }
                    else
                    {
                        Console.WriteLine(SecondPlayer.UserName + ", your move:");
                        symbol = Convert.ToString(Console.ReadLine());
                        if (symbol == "+")
                        {
                            Console.WriteLine($"Congratulations! {SecondPlayer.UserName} is a winner");
                            SecondPlayer.WinGame(firstPlayer.UserName, Raiting);
                            firstPlayer.LoseGame(SecondPlayer.UserName, Raiting);
                            second_player_earned_raiting += Raiting;
                            if (first_player_earned_raiting - Raiting < 1)
                            {
                                first_player_earned_raiting = 1;
                            }
                            else
                            {
                                first_player_earned_raiting -= Raiting;
                            }
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
                return;
            }
            Console.WriteLine("Game number " + Number + ":");
            Console.WriteLine("The best player is " + BestPlayer.UserName);
            if (first_player_earned_raiting > second_player_earned_raiting)
            {
                Console.WriteLine("Raiting in this game: " + first_player_earned_raiting);
            }
            else if (second_player_earned_raiting > first_player_earned_raiting)
            {
                Console.WriteLine("Raiting in this game: " + second_player_earned_raiting);
            }
            Console.WriteLine("Total raiting " + BestPlayer.CurrentRaiting + "\n\n");
        }
        public Game()
        {
            Game_number_seed++;
        }
    }
}
