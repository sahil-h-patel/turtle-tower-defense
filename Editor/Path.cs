using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    internal class Path
    {
        private Panel path;
        private PictureBox[,] pathGrid = new PictureBox[16, 28];
        private const int boxHeight = 20;
        private const int boxWidth = 20;
        private bool filled;


        public Path(Panel path)
        {
            this.path = path;
            path.Height = boxHeight * pathGrid.GetLength(0);
            path.Width = boxWidth * pathGrid.GetLength(1);
            SetUpGrid();
        }

        public bool Filled { get { return filled; } }

        public void SetUpGrid()
        {
            for (int x = 0; x < pathGrid.GetLength(0); x++)
            {
                for (int y = 0; y < pathGrid.GetLength(1); y++)
                {
                    pathGrid[x, y] = new PictureBox();
                    pathGrid[x, y].Size = new Size(boxWidth, boxHeight);
                    pathGrid[x, y].Location = new Point(y * boxWidth,
                       x * boxHeight);
                    path.Controls.Add(pathGrid[x, y]);
                    pathGrid[x, y].MouseMove += MouseMove;
                    pathGrid[x, y].MouseDown += MouseDown;
                }
            }
        }

        protected void MouseMove(object? sender, MouseEventArgs e)
        {

            if (sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                if (e.Button == MouseButtons.Left)
                {
                    pb.BackColor = Color.Gray;
                    filled = true;
                }
            }
        }

        protected void MouseDown(object? sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                pb.Capture = false;
                pb.BackColor = Color.Gray;
                filled = true;
            }
        }

        public bool Clear()
        {
            for (int x = 0; x < pathGrid.GetLength(0); x++)
            {
                for (int y = 0; y < pathGrid.GetLength(1); y++)
                {
                    if (pathGrid[x, y].BackColor == Color.Gray)
                    {
                        pathGrid[x, y].BackColor = Color.FromKnownColor(KnownColor.Transparent);
                    }
                }
            }
            return false;
        }

        public Path Copy()
        {
            Path pathCopy = new Path(path);
            for (int x = 0; x < pathGrid.GetLength(0); x++)
            {
                for (int y = 0; y < pathGrid.GetLength(1); y++)
                {
                    pathCopy.pathGrid[x, y] = new PictureBox();
                    pathCopy.pathGrid[x, y].BackColor = pathGrid[x, y].BackColor;
                }
            }
            return pathCopy;
        }

        public void Show()
        {
            for (int x = 0; x < pathGrid.GetLength(0); x++)
            {
                for (int y = 0; y < pathGrid.GetLength(1); y++)
                {
                    pathCopy.pathGrid[x, y] = new PictureBox();
                    pathCopy.pathGrid[x, y].BackColor = pathGrid[x, y].BackColor;
                }
            }
        }
    }
}
