using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_ЛР__3_справжня
{
    public class GameFactory
    {
        public BaseGame CreateGame(string typeGame)
        {
            if (typeGame == "Base")
            {
                return new Game();
            }
            if (typeGame == "Training")
            {
                return new TrainingGame();
            }
            if (typeGame == "OnePlayerRisk")
            {
                return new OnePLayerRiskGame();
            }
            else
            {
                return null;
            }
        }
    }
}
