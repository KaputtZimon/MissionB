using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionBlack
{
    class Stats
    {
        private int liv = 5;
        private int scr = 0;
        private double hit = 0;
        private double mis = 0;
        private double acc = 0;
        private int rnd = 1;
        private int rndLT = 15;
        private int gameLT = 180;
        private int minTOH = 0;
        private int maxTOH = 0;
        private int avgTOH = 0;
        /*private int bullseye = 0;
        private int missesBeforeTarget = 0;
        private int missesAfterTarget = 0;*/
        private string pauseInfo = "Press P to Pause";

        Font boldFont = new System.Drawing.Font(Mainframe.ActiveForm.Font.FontFamily, Mainframe.ActiveForm.Font.SizeInPoints, FontStyle.Bold);

        public int lives { get{ return liv; } set { liv = value; } }
        public int score { get { return scr; } set { scr = value; } }
        public double hits { get { return hit; } set { hit = value; } }
        public double misses { get { return mis; } set { mis = value; } }
        public double accuracy { get { return acc; } set { acc = value; } }
        public int round { get { return rnd; } set { rnd = value; } }
        public int roundLeftTime { get { return rndLT; } set { rndLT = value; } }
        public int gameLeftTime { get { return gameLT; } set { gameLT = value; } }
        public int minTimeOfHit { get { return minTOH; } set { minTOH = value; } }
        public int maxTimeOfHit { get { return maxTOH; } set { maxTOH = value; } }
        public int averageTimeOfHit { get { return avgTOH; } set { avgTOH = value; } }


        public Stats()
        {

        }
        public void DrawImage(Graphics graphic)
        {
            graphic.DrawString("Round: "+rnd.ToString(), boldFont, Brushes.DarkGray, 10, 10);
            graphic.DrawString("Score: "+scr.ToString(), boldFont, Brushes.DarkGray, 110, 10);
            graphic.DrawString(gameLT.ToString(), boldFont, Brushes.White, 230, 10);
            graphic.DrawString(rndLT.ToString(), boldFont, Brushes.White, 280, 10);
            graphic.DrawString(pauseInfo, boldFont, Brushes.Gray, 340, 10);
            graphic.DrawString(liv.ToString(), boldFont, Brushes.White, 480, 10);
            graphic.DrawString("Hits: " + hit.ToString(), boldFont, Brushes.DarkGray, 10, 480);
            graphic.DrawString("Misses: " + mis.ToString(), boldFont, Brushes.DarkGray, 110, 480);
            graphic.DrawString("Accuracy: " + Math.Round(acc).ToString()+"%", boldFont, Brushes.DarkGray, 230, 480);
        }

    }
}
