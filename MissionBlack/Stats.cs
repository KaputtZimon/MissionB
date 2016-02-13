using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionBlack
{
    class Stats
    {
        /*private int bullseye = 0;
        private int missesBeforeTarget = 0;
        private int missesAfterTarget = 0;*/
        private readonly string pauseInfo = "Press P to Pause";

        readonly Font boldFont = new System.Drawing.Font(Mainframe.ActiveForm.Font.FontFamily, Mainframe.ActiveForm.Font.SizeInPoints, FontStyle.Bold);

        public int Lives { get; set; } = 5;
        public int Score { get; set; } = 0;
        public double Hits { get; set; } = 0;
        public double Misses { get; set; } = 0;
        public double Accuracy { get; set; } = 0;
        public int Round { get; set; } = 1;
        public int RoundLeftTime { get; set; } = 15;
        public int GameLeftTime { get; set; } = 180;
        public int MinTimeOfHit { get; set; } = 0;
        public int MaxTimeOfHit { get; set; } = 0;
        public int AverageTimeOfHit { get; set; } = 0;

        
        public void DrawImage(Graphics graphic)
        {
            graphic.DrawString("Round: "+Round.ToString(), boldFont, Brushes.DarkGray, 10, 10);
            graphic.DrawString("Score: "+Score.ToString(), boldFont, Brushes.DarkGray, 110, 10);
            graphic.DrawString(GameLeftTime.ToString(), boldFont, Brushes.White, 230, 10);
            graphic.DrawString(RoundLeftTime.ToString(), boldFont, Brushes.White, 280, 10);
            graphic.DrawString(pauseInfo, boldFont, Brushes.Gray, 340, 10);
            graphic.DrawString(Lives.ToString(), boldFont, Brushes.White, 480, 10);
            graphic.DrawString("Hits: " + Hits.ToString(CultureInfo.InvariantCulture), boldFont, Brushes.DarkGray, 10, 480);
            graphic.DrawString("Misses: " + Misses.ToString(), boldFont, Brushes.DarkGray, 110, 480);
            graphic.DrawString("Accuracy: " + Math.Round(Accuracy).ToString()+"%", boldFont, Brushes.DarkGray, 230, 480);
        }

    }
}