using System;

namespace MissionBlack
{
    class InterfaceManager : Stats
    {

        public Action AddTargetAction { get; set; }
       
        public void Update()
        {
            if (Lives == 0)
            {
                //End of game
            }
            if (GameLeftTime == 0)
            {
                //End of game
            }
            if (RoundLeftTime == 0)
            {
                RoundLeftTime = 15;
                Round = Round + 1;

                AddTargetAction?.Invoke();                
            }
            GameLeftTime = GameLeftTime - 1;
            RoundLeftTime = RoundLeftTime - 1;
        }
        public void Hit()
        {
            Hits = Hits + 1;
            Accuracy = (Hits / (Hits + Misses)) * 100;
            Score = Score + 1000;
        }
        public void Miss()
        {
            Misses = Misses + 1;
            Accuracy = Hits / (Hits + Misses) * 100;
            Score = Score - 5000;
        }
        public void Failed(int fails)
        {
            Lives = Lives - fails;
        }
    }
}
