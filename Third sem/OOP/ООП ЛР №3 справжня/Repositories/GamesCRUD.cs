using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня.Repositories
{
    internal class GamesCRUD : GamesRepository
    {
        private DBContext dataBase;
        public GamesCRUD(DBContext dataBase)
        {
            this.dataBase = dataBase;
        }
        public void Create(GamesEntity entity)
        {
            dataBase.Games.Add(entity);
        }
        public List<GamesEntity> Read()
        {
            return dataBase.Games;
        }
        public void Update(GamesEntity entity, long id)
        {
            if (id >= 0 && id < dataBase.Games.Count)
            {
                dataBase.Games[(int)id] = entity;
            }
            else
            {
                Console.WriteLine("Неможливо оновити данi для гри з iдентифiкатором"+ id+ ", оскiльки гри з таки номером не iснує");
            }
        }
        public void Delete(GamesEntity entity)
        {
            dataBase.Games.Remove(entity);
        }
    }
}
