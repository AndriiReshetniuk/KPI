﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR_2
{
    public class Round
    {
        public string opponentName;
        public long Raiting;
        public string resultGame;
        public string gameIndex;
        public Round(string opponentName, long Raiting, string resultGame, long gameIndex)
        {
            this.opponentName = opponentName;
            this.Raiting = Raiting;
            this.resultGame = resultGame;
            this.gameIndex = gameIndex.ToString();
        }
    }
}
