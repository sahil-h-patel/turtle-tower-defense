using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{

    enum Type
    {
        Sand = 00,
        ForwardNorth = 10,
        ForwardEast = 11,
        ForwardSouth = 12,
        ForwardWest = 13,
        TurnNorth = 20,
        TurnEast = 21,
        TurnSouth = 22,
        TurnWest = 23,
        SplitUpDown = 30,
        SplitLeftRight = 31,
    }

    internal class Path
    {
        private Panel path;
        private PictureBox selectedTile;
        public PictureBox[,] pathGrid = new PictureBox[16, 28];
        private const int boxHeight = 40;
        private const int boxWidth = 40;
        private bool filled;


        public Path(Panel path, PictureBox selectedTile)
        {
            this.path = path;
            this.selectedTile = selectedTile;
            path.Height = boxHeight * pathGrid.GetLength(0);
            path.Width = boxWidth * pathGrid.GetLength(1);
            SetUpGrid();
        }

        public bool Filled { get { return filled; } }
        public int Width { get { return pathGrid.GetLength(0); } }
        public int Height { get { return pathGrid.GetLength(1); } }

        public void SetUpGrid()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    pathGrid[x, y] = new PictureBox();
                    pathGrid[x, y].Size = new Size(boxWidth, boxHeight);
                    pathGrid[x, y].Location = new Point(y * boxWidth, x * boxHeight);
                    pathGrid[x, y].Tag = Type.Sand;
                    pathGrid[x, y].Load("../../../Resources/sandTexture.png");
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
                    pb.Image = selectedTile.Image;
                    for (int x = 0; x < Width; x++)
                    {
                        for (int y = 0; y < Height; y++)
                        {
                            if (pathGrid[x, y].Location == pb.Location)
                            {
                                pathGrid[x, y].Tag = selectedTile.Tag;
                                return;
                            }
                        }
                    }
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
                pb.Image = selectedTile.Image;
                
                for(int x = 0; x < Width; x++)
                {
                    for(int y = 0; y < Height; y++)
                    {
                        if (pathGrid[x,y].Location == pb.Location)
                        {
                            pathGrid[x,y].Tag = selectedTile.Tag;
                            return;
                        }
                    }
                }
                filled = true;
            }
        }

        public bool Clear()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    pathGrid[x, y].Load("../../../Resources/sandTexture.png");
                    pathGrid[x, y].Tag = Type.Sand;
                }
            }
            return false;
        }

        public Path Copy()
        {
            Path pathCopy = new Path(path, selectedTile);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    pathCopy.pathGrid[x, y].Tag = pathGrid[x, y].Tag;
                    
                }
            }
            return pathCopy;
        }
    }
}
