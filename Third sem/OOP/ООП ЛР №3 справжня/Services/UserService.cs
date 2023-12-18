using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООП_ЛР__3_справжня.Repositories;

namespace ООП_ЛР__3_справжня.Services
{
    public class UserService: IUserService
    {
        public UsersRepository repository { get; set; }
        public UserService(DBContext context)
        {
            repository = new UsersCRUD(context);
        }
        public void createAccount(UsersEntity entity)
        {
            repository.Create(entity);
        }
        public List<UsersEntity> ReadAccounts()
        {
            return repository.Read();
        }
        public UsersEntity ReadAccountByName(string Name)
        {
            List<UsersEntity> Users = repository.Read();
            for(int i = 0; i<Users.Count; i++)
            {
                if (Users[i].UserName == Name)
                {
                    return Users[i];
                }
            }
            Console.WriteLine("Користувача з таким iменем не iснує");
            return null;
        }
        public void UpdateAccountInfo(UsersEntity newInfo, string name)
        {
            repository.Update(newInfo, name);
        }
    }
}
