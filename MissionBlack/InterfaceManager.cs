using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionBlack
{
    class InterfaceManager : Stats
    {
        public InterfaceManager()
        {

        }
        public void Update()
        {
            if (lives == 0)
            {
                //End of game
            }
            if (gameLeftTime == 0)
            {
                //End of game
            }
            if (roundLeftTime == 0)
            {
                roundLeftTime = 15;
                round = round + 1;
            }
            gameLeftTime = gameLeftTime - 1;
            roundLeftTime = roundLeftTime - 1;
        }
        public void Hit()
        {
            hits = hits + 1;
            accuracy = (hits / (hits + misses)) * 100;
        }
        public void Miss()
        {
            misses = misses + 1;
            accuracy = hits / (hits + misses) * 100;
        }
        public void Failed(int fails)
        {
            lives = lives - fails;
        }
    }
}
