using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня.Repositories
{
    internal class UsersCRUD : UsersRepository
    {
        private DBContext dataBase;
        public UsersCRUD(DBContext dataBase)
        {
           this.dataBase = dataBase;
        }
        public void Create(UsersEntity entity)
        {
            dataBase.Users.Add(entity);
        }
        public List<UsersEntity> Read()
        {
            return dataBase.Users;
        }
        public void Update(UsersEntity entity, string name)
        {
            for(int i = 0; i<dataBase.Users.Count; i++)
            {
                if (dataBase.Users[i].UserName == name)
                {
                    dataBase.Users[i] = entity;
                }
            }
        }
        public void Delete(UsersEntity entity)
        {
            dataBase.Users.Remove(entity); //
        }
    }
}
