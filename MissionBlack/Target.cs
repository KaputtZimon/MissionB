using MissionBlack.Properties;
using System.Drawing;

namespace MissionBlack
{
    class Target : ImageBase
    {
        public Target() : base(Resources.Target)
        {
        }

        public PointF Origin
        {
            get { return new PointF(ILeft, ITop); }
        }

        public double CurrentRadius
        {
            get
            {
                return (double)(Width / 2);
            }
        }

        public bool Update()
        {
            if (Growing)
            {
                Width = Width + 8;
                Height = Height + 8;
                Left = ILeft - (Width / 2);
                Top = ITop - (Height / 2);
                if (Width >= 80 && Height >= 80) Growing = false;
                return false;
            }
            else
            {
                Width = Width - 8;
                Height = Height - 8;
                Left = ILeft - (Width / 2);
                Top = ITop - (Height / 2);
                return Width <= 0 && Height <= 0;
            }
        }
    }
}
