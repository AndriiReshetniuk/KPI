using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_4_ООП.Terminal
{
    public interface CommandInterface
    {
        public void Execute();
        public void ShowAllUsers();
        public void AddPlayerCommand();
        public void ShowPlayerStats();
        public void PlayGameCommand();
        public string GetName();
        public void GetHelp();
        public string GetDescription();
        public void ShowGameOfPlayer();
    }
}
