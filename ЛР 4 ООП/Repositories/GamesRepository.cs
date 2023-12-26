using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_4_ООП;

namespace ЛР_4_ООП.Repositories
{
    public interface GamesRepository
    {
        public BaseGame Create(string ID, string GameType, List<UsersEntity> players, UsersEntity BestPlayer = null);
        public List<GamesEntity> Read();
        public void Update(long id, string GameType, List<UsersEntity> players, UsersEntity BestPlayer = null);
        public void Delete(GamesEntity entity);
    }
}
