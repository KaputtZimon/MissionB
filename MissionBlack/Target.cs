using MissionBlack.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionBlack
{
    class Target : ImageBase
    {
        //private Rectangle targetArea = new Rectangle();
        

        public Target() : base(Resources.Target)
        {
        }

        public PointF Origin
        {
            get
            {
                return new PointF(iLeft, iTop);
            }
        }
        public double CurrentRadius
        {
            get
            {
                return (double)(width / 2);
            }
        }

        public bool Update()
        {
            if (growing)
            {
                width = width + 8;
                height = height + 8;
                left = iLeft - (width / 2);
                top = iTop - (height / 2);
                if (width >= 80 && height >= 80) growing = false;
                return false;
            }
            else
            {
                width = width - 8;
                height = height - 8;
                left = iLeft - (width / 2);
                top = iTop - (height / 2);
                if (width <= 0 && height <= 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
