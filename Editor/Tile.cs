using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    internal class Tile
    {
        private PictureBox box;
        private Image image;
        string imgName;
        private int x;
        private int y;

        public Tile(int x, int y, PictureBox box, string imgName)
        {
            this.x = x;
            this.y = y;
            this.box = box;
            this.imgName = imgName;            
        }

        public Tile(int x, int y, PictureBox box)
        {
            this.x = x;
            this.y = y;
            this.box = box;
        }

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public PictureBox PictureBox { get { return box; } set { box = value; } }
        public Image Image { get { return image; } set { image = value; } }

        //public void SetImage()
        //{
        //    box.Image
        //    box.Load(imgName);
        //}
    }
}
