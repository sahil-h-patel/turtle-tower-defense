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
        TurnLeftNorth = 20,
        TurnLeftEast = 21,
        TurnLeftSouth = 22,
        TurnLeftWest = 23,
        TurnRightNorth = 30,
        TurnRightEast = 31,
        TurnRightSouth = 32,
        TurnRightWest = 33,
        SplitUpDown = 40,
        SplitLeftRight = 41,
        Start = 50,
        End = 60,
    }

    internal class Path
    {
        private Panel path;
        private PictureBox selectedTile;
        public PictureBox[,] pathGrid = new PictureBox[16, 31];
        private const int boxHeight = 40;
        private const int boxWidth = 40;
        private bool filled;
        private bool loaded;


        public Path(Panel path, PictureBox selectedTile, bool loading)
        {
            this.path = path;
            this.selectedTile = selectedTile;
            path.Height = boxHeight * pathGrid.GetLength(0);
            path.Width = boxWidth * pathGrid.GetLength(1);
            if (!loading)
            {
                SetUpGrid();
            }
        }

        public bool Filled { get { return filled; } }
        public int Width { get { return pathGrid.GetLength(0); } }
        public int Height { get { return pathGrid.GetLength(1); } }
        public bool Loaded { get { return loaded; } set { loaded = value; } }

        public void SetUpGrid()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    pathGrid[x, y] = new PictureBox
                    {
                        Size = new Size(boxWidth, boxHeight),
                        Location = new Point(y * boxWidth, x * boxHeight),
                        Tag = Type.Sand
                    };
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
                                pathGrid[x, y].Image = selectedTile.Image;
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
                            pathGrid[x, y].Image = selectedTile.Image;
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
            Path pathCopy = new Path(path, selectedTile, false);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    pathCopy.pathGrid[x, y].Tag = pathGrid[x, y].Tag;
                    pathCopy.pathGrid[x, y].ImageLocation = pathGrid[x, y].ImageLocation;
                }
            }
            return pathCopy;
        }

        public void Load(StreamReader input)
        {
            string line;

            int x = 0;
            while ((line = input.ReadLine()) != null)
            {
                string[] stringData = line.Split(',');
                int[] data = ConvertInt32Array(stringData);
                for (int y = 0; y < data.Length; y++)
                {
                    pathGrid[x, y] = new PictureBox();
                    pathGrid[x, y].Size = new Size(40, 40);
                    pathGrid[x, y].Location = new Point(y * 40, x * 40);
                    pathGrid[x, y].Tag = (Type)data[y];
                    pathGrid[x, y].ImageLocation = TagToPath(pathGrid[x, y]);
                    pathGrid[x, y].MouseDown += MouseDown;
                    pathGrid[x, y].MouseMove += MouseMove;
                }
                x++;
            }
        }

        private int[] ConvertInt32Array(string[] array)
        {
            int[] intArrray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                intArrray[i] = Convert.ToInt32(array[i]);
            }
            return intArrray;
        }

        private string TagToPath(PictureBox pb)
        {
            switch ((Type)pb.Tag)
            {
                case Type.Sand:
                    return "../../../Resources/sandTexture.png";
                case Type.ForwardNorth:
                    return "../../../Resources/straightPath.png";
                case Type.ForwardEast:
                    return "../../../Resources/straightPath.png";
                case Type.ForwardSouth:
                    return "../../../Resources/straightPath.png";
                case Type.ForwardWest:
                    return "../../../Resources/straightPath.png";
                case Type.TurnLeftNorth:
                    return "../../../Resources/turnLeftPath.png";
                case Type.TurnLeftEast:
                    return "../../../Resources/turnLeftPath.png";
                case Type.TurnLeftSouth:
                    return "../../../Resources/turnLeftPath.png";
                case Type.TurnLeftWest:
                    return "../../../Resources/turnLeftPath.png";
                case Type.TurnRightNorth:
                    return "../../../Resources/turnRightPath.png";
                case Type.TurnRightEast:
                    return "../../../Resources/turnRightPath.png";
                case Type.TurnRightSouth:
                    return "../../../Resources/turnRightPath.png";
                case Type.TurnRightWest:
                    return "../../../Resources/turnRightPath.png";
                case Type.SplitUpDown:
                    return "../../../Resources/splitPath.png";
                case Type.SplitLeftRight:
                    return "../../../Resources/splitPath.png";
                default:
                    return null;
            }
        }
    }
}
