using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП;
using ЛР_4_ООП.Repositories;

namespace ЛР_4_ООП.Services
{
    public class UserService : IUserService
    {
        public UsersRepository repository { get; set; }
        public UserService(DBContext context)
        {
            repository = new UsersCRUD(context);
        }
        public UsersEntity createAccount(string UserName, string typeOfUsers)
        {
            return repository.Create(UserName, typeOfUsers);
        }
        public List<UsersEntity> ReadAccounts()
        {
            return repository.Read();
        }
        public UsersEntity ReadAccountByName(string Name)
        {
            List<UsersEntity> Users = repository.Read();
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserName == Name)
                {
                    return Users[i];
                }
            }
            Console.WriteLine("Player with this name does not exist");
            return null;
        }
        public void UpdateAccountInfo(string UserName, string typeOfUsers, UsersEntity entity, long Rait = 0, string opponentName = "", long GamesCount = 0, long countOfWinningGames = 0, long countOfLostGames = 0)
        {
            repository.Update(UserName, typeOfUsers, entity, Rait, opponentName, GamesCount, countOfWinningGames, countOfLostGames);
        }
        public void showUserInfo(string UserName)
        {
            UsersEntity entity = this.ReadAccountByName(UserName);
            AccountFactory factory = new AccountFactory();
            var account = factory.CreateAccount(UserName, entity.typeOfUsers);
            account.allRound = entity.rounds;
            Console.WriteLine("User name:" + entity.UserName);
            Console.WriteLine("Curent Raiting: " + entity.CurrentRaiting);
            Console.WriteLine("Games count: " + entity.GamesCount);
            Console.WriteLine("History:\n" + account.GetStats());
        }
    }
}
