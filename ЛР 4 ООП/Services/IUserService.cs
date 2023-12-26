using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП.Repositories;

namespace ЛР_4_ООП.Services
{
    internal interface IUserService
    {
        public UsersRepository repository { get; set; }
        public UsersEntity createAccount(string UserName, string typeOfUsers);
        public List<UsersEntity> ReadAccounts();
        public UsersEntity ReadAccountByName(string Name);
        public void UpdateAccountInfo(string UserName, string typeOfUsers, UsersEntity entity, long Rait = 0, string opponentName = "", long GamesCount = 0, long countOfWinningGames = 0, long countOfLostGames = 0);
    }
}
