using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня.Repositories
{
    public interface UsersRepository
    {
        public void Create(UsersEntity entity);
        public List<UsersEntity> Read();
        public void Update(UsersEntity entity, string name);
        public void Delete(UsersEntity entity);
    }
}
