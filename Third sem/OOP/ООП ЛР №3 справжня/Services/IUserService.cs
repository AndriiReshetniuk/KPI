using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ООП_ЛР__3_справжня.Repositories;

namespace ООП_ЛР__3_справжня.Services
{
    internal interface IUserService
    {
        public UsersRepository repository { get; set; }
        public void createAccount(UsersEntity entity);
        public List<UsersEntity> ReadAccounts();
        public UsersEntity ReadAccountByName(string Name);
        public void UpdateAccountInfo(UsersEntity newInfo, string name);
    }
}
