using System.Drawing;

namespace MissionBlack
{
    class ImageBase
    {
        public Bitmap Bitmap;
        public int ILeft { get; set; }
        public int ITop { get; set; }
        public int Left { get; set; } = 0;
        public int Top { get; set; } = 0;
        public int Width { get; set; } = 1;
        public int Height { get; set; } = 1;
        public bool Growing { get; set; } = true;

        public ImageBase(Bitmap resource)
        {
            Bitmap = new Bitmap(resource);
        }

        public void DrawImage(Graphics graphic)
        {
            graphic.DrawImage(Bitmap, Left, Top, Width, Height);
        }
    }
}