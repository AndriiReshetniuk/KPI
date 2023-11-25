using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR_2
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
            if (typeGame == "OnePlayer")
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
