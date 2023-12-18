using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня.Repositories
{
    public interface GamesRepository
    {
        public void Create(GamesEntity entity);
        public List<GamesEntity> Read();
        public void Update(GamesEntity entity, long id);
        public void Delete(GamesEntity entity);
    }
}
