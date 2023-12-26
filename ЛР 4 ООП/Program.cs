using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Services;
using ЛР_4_ООП.Terminal;
namespace ЛР_4_ООП
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBContext context = new DBContext();
            GameService gameService = new GameService(context);
            UserService userService = new UserService(context);
            TerminalClass terminal = new TerminalClass(userService, gameService);
            terminal.StartTerminal();
        }
    }
}
