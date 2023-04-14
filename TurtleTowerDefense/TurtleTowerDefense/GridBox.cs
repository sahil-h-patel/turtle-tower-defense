using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    /// <summary>
    /// a single box in the grid
    /// </summary>
    internal class GridBox
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private Rectangle rect;
        private bool isFilled;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Rectangle Rect
        {
            get { return rect; }
        }

        public bool IsFilled
        {
            get { return isFilled; }
            set { isFilled = value; }
        }

        public GridBox(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            rect = new Rectangle(x, y, width, height);
            isFilled = false;
        }

        public bool Contains(Point p)
        {
            if (X <= p.X && p.X < X + width && Y <= p.Y)
            {
                return p.Y < Y + height;
            }

            return false;
        }
    }
}
