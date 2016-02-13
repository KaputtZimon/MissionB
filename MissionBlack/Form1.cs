using MissionBlack.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionBlack
{
    public partial class Mainframe : Form
    {
        private bool paused = false;

        private int timerTmp = 0;
        private int timeCounter = 0;
        private int timeTarget = 0;

        InterfaceManager ifm = new InterfaceManager();

        Random rnd = new Random();
        Target target;
        List<Target> targets = new List<Target>();
        List<Target> targetsDead = new List<Target>();

        Pause pause; 

        public Mainframe()
        {
            InitializeComponent();

            Bitmap b = new Bitmap(Resources.Site);
            this.Cursor = MissionBlack.Cursor.CreateCursor(b, b.Height / 2, b.Width / 2);

            targets.Add(target = new Target() { iLeft = rnd.Next(100,400), iTop = rnd.Next(100, 400), width = 0, height = 0});//Needs window width/height dependency

            pause = new Pause() { left = 0, top = 32, width = 500, height = 436 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            if (!paused)
            {
                foreach (Target tar in targets)
                {
                    tar.DrawImage(dc);
                }
            }
            else{
                pause.DrawImage(dc);
            }
            ifm.DrawImage(dc);
            base.OnPaint(e);
        }

        private void Mainframe_MouseMove(object sender, MouseEventArgs e)
        {

            //this.Refresh();
        }

        private void Mainframe_MouseClick(object sender, MouseEventArgs e)
        {
            PointF mouse = new PointF(e.X, e.Y);

            var hit = targets.Where(tar => GetDistance(mouse, tar.Origin) <= tar.CurrentRadius).FirstOrDefault();
            if (hit != null)
            {
                targets.Remove(hit);
                targets.Add(target = new Target() { iLeft = rnd.Next(100, 400), iTop = rnd.Next(100, 400), width = 0, height = 0 });
            }
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (!paused)
            {
                timerTmp = Math.DivRem(timeCounter, 1000, out timeTarget);
                if (timeTarget == 0)
                //if(true)
                {
                    UpdateTargets();
                }
                this.Refresh();
                timeCounter = timeCounter + 10;
            }
            else
            {
                this.Refresh();
            }
        }

        private void UpdateTargets()
        {
            targetsDead.Clear();
            foreach (Target tar in targets)
            {
                if (tar.Update())
                {
                    targetsDead.Add(tar);
                }
            }

            if(targetsDead.Count > 0)
            {
                ifm.Failed(targetsDead.Count);
                foreach (Target tarD in targetsDead)
                {
                    targets.Remove(tarD);
                    targets.Add(target = new Target() { iLeft = rnd.Next(100, 400), iTop = rnd.Next(100, 400), width = 0, height = 0 });
                }
            }
        }

        private void TimerSeconds_Tick(object sender, EventArgs e)
        {
            UpdateStats();
        }
        private void UpdateStats()
        {
                ifm.Update();
        }

        private void Mainframe_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.P && !paused)
            {
                TimerSeconds.Stop();
                //GameLoop.Stop();
                this.Refresh();
                paused = true;
            }
            else if (e.KeyCode == Keys.P && paused)
            {
                TimerSeconds.Start();
                //GameLoop.Start();
                this.Refresh();
                paused = false;
            }
        }
        private void Mainframe_Click(object sender, MouseEventArgs e)
        {
            
        }

        private double GetDistance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(p1.X) - Math.Abs(p2.X), 2) + Math.Pow(Math.Abs(p1.Y) - Math.Abs(p2.Y), 2));
        }
    }
}
