using MissionBlack.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MissionBlack
{
    public sealed partial class Mainframe : Form
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

        readonly Pause pause; 

        public Mainframe()
        {
            
            InitializeComponent();

            ifm.AddTargetAction = AddTarget;

            var b = new Bitmap(Resources.Site);
            this.Cursor = MissionBlack.Cursor.CreateCursor(b, b.Height / 2, b.Width / 2);

            //TODO:use  Size.Width / Size.Height
            targets.Add(target = new Target() { ILeft = rnd.Next(100,400), ITop = rnd.Next(100, 400), Width = 0, Height = 0});

            pause = new Pause() { Left = 0, Top = 32, Width = 500, Height = 436 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var dc = e.Graphics;
            if (paused)
                pause.DrawImage(dc);
            else
            {
                foreach (var tar in targets)
                    tar.DrawImage(dc);
            }

            ifm.DrawImage(dc);
            base.OnPaint(e);
        }

        private void Mainframe_MouseClick(object sender, MouseEventArgs e)
        {
            var mouse = new PointF(e.X, e.Y);

            var hit = targets.FirstOrDefault(tar => GetDistance(mouse, tar.Origin) <= tar.CurrentRadius);
            if (hit != null)
            {
                targets.Remove(hit);
                ifm.Hit();
                targets.Add(target = new Target() { ILeft = rnd.Next(100, 400), ITop = rnd.Next(100, 400), Width = 0, Height = 0 });
            }
            else
            {
                ifm.Miss();
            }
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (paused)
                this.Refresh();
            else
            {
                timerTmp = Math.DivRem(timeCounter, 100, out timeTarget);
                if (timeTarget == 0)
                    UpdateTargets();
                this.Refresh();
                timeCounter = timeCounter + 10;
            }
        }

        private void UpdateTargets()
        {
            targetsDead.Clear();
            foreach (var tar in targets)
            {
                if (tar.Update())
                    targetsDead.Add(tar);
            }

            if(targetsDead.Count > 0)
            {
                ifm.Failed(targetsDead.Count);
                foreach (var tarD in targetsDead)
                {
                    targets.Remove(tarD);
                    targets.Add(target = new Target() { ILeft = rnd.Next(100, 400), ITop = rnd.Next(100, 400), Width = 0, Height = 0 });
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
                this.Refresh();
                paused = true;
            }
            else if (e.KeyCode == Keys.P && paused)
            {
                TimerSeconds.Start();
                this.Refresh();
                paused = false;
            }
        }

        private double GetDistance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(p1.X) - Math.Abs(p2.X), 2) + Math.Pow(Math.Abs(p1.Y) - Math.Abs(p2.Y), 2));
        }

        public void AddTarget()
        {
            targets.Add(target = new Target() { ILeft = rnd.Next(100, 400), ITop = rnd.Next(100, 400), Width = 0, Height = 0 });
        }
    }
}
