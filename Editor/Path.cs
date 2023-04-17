﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{

    enum Type
    {
        Forward,
        Left_Turn,
        Right_Turn,
        Split,
        Sand
    }

    internal class Path
    {
        private Panel path;
        private PictureBox selectedTile;
        public PictureBox[,] pathGrid = new PictureBox[16, 28];
        private List<Image> images = new List<Image>();
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
                    SetImage(pathGrid[x, y], pathGrid[x, y].Tag);
                    path.Controls.Add(pathGrid[x, y]);
                    pathGrid[x, y].MouseMove += MouseMove;
                    pathGrid[x, y].MouseDown += MouseDown;
                }
            }
        }

        protected static void SetImage(PictureBox pb, object? tag)
        {
            if(tag is Type)
            {
                Type type = (Type)tag;
                switch (type)
                {
                    case Type.Forward:
                        pb.Load("../../../Resources/straightPath.png");
                        break;
                    case Type.Left_Turn:
                        pb.Load("../../../Resources/turnLeftPath.png");
                        break;
                    case Type.Right_Turn:
                        pb.Load("../../../Resources/straightPath.png");
                        break;
                    case Type.Split:
                        pb.Load("../../../Resources/splitPath.png");
                        break;
                    case Type.Sand:
                        pb.Load("../../../Resources/sandTexture.png");
                        break;
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
                filled = true;
            }
        }

        public bool Clear()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
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
            Path pathCopy = new Path(path, selectedTile);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (pathGrid[x,y].BackColor == Color.Gray)
                    {
                        pathCopy.pathGrid[x, y].BackColor = Color.Gray;
                    }
                }
            }
            return pathCopy;
        }

        public void LoadImages()
        {
   
        }
    }
}
