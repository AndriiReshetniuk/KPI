using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_4_ООП
{
    public class Game : BaseGame
    {
        protected override void ChooseRaitingBet(BaseAccount firstPlayer, BaseAccount secondPlayer)
        {
            Console.WriteLine("Choose a rating rate:");
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
    }
}


