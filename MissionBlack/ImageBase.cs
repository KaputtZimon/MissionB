using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionBlack
{
    class ImageBase
    {
        public Bitmap bitmap;
        private int bX = 0;
        private int bY = 0;
        private int bWidth = 1;
        private int bHeight = 1;
        private int initialLeft;
        private int initialTop;
        private bool grow = true;

        public int iLeft { get { return initialLeft; } set { initialLeft = value; } }
        public int iTop { get { return initialTop; } set { initialTop = value; } }
        public int left { get { return bX; } set { bX = value; } }
        public int top { get { return bY; } set { bY = value; } }
        public int width { get { return bWidth; } set { bWidth = value; } }
        public int height { get { return bHeight; } set { bHeight = value; } }
        public bool growing { get { return grow; } set { grow = value; } }

        public ImageBase(Bitmap resource)
        {
            bitmap = new Bitmap(resource);
        }

        public void DrawImage(Graphics graphic)
        {
            graphic.DrawImage(bitmap, bX, bY, bWidth, bHeight);
        }

    }
}
