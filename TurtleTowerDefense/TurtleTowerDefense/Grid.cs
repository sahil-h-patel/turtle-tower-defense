
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeUtils;
using Microsoft.Xna.Framework.Input;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework.Graphics;

namespace TurtleTowerDefense
{
    /// <summary>
    /// handles grid system for tower placement
    /// </summary>
    internal class Grid
    {
        private GridBox[,] grid;
        private bool[,] isFilled;
        private int boxWidth;
        private int boxHeight;
        private bool isVisible;
        private bool validPlacement;

        /// <summary>
        /// Retrieves the entire gridbox, or sets it to a new value.
        /// </summary>
        public GridBox[,] GridBoxes{ get { return grid; } set { grid = value; } }

        /// <summary>
        /// creates a grid based on given width and height in boxes
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Grid(int width, int height)
        {
            grid = new GridBox[width, height];
            isFilled = new bool[width, height];
            boxWidth = 40;
            boxHeight = 40;
            SetUpGrid();

            //initially makes the grid invisible
            isVisible = true;
        }

        /// <summary>
        /// returns whether the grid should be drawn or not
        /// </summary>
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        /// <summary>
        /// fills grid array with rectangles
        /// </summary>
        private void SetUpGrid()
        {
            for (int c = 0; c < grid.GetLength(0); c++)
            {
                for (int r = 0; r < grid.GetLength(1); r++)
                {
                    //creates new rectangle inside the grid
                    grid[c, r] = new GridBox((boxWidth * r), (boxHeight * c) + 80, boxWidth, boxHeight);
                    
                }
            }

         
        }

        /// <summary>
        /// draws grid, highlights where the mouse is hovering over
        /// </summary>
        public void DrawGrid(MouseState mouse, TowerType tower)
        {
            for (int c = 0; c < grid.GetLength(0); c++)
            {
                for (int r = 0; r < 26; r++)
                {
                    //check if mouse is hovering over box
                    if (grid[c, r].Contains(mouse.Position))
                    {
                        
                        //initially set to be wrong
                        validPlacement = false;

                        if (c + 1 >= grid.GetLength(0) || r + 1 >= grid.GetLength(1))
                        {
                            //if selected area is out of bounds
                            ShapeBatch.Box(grid[c, r].Rect, new Color(Color.Red, 0.02f));

                            if (c + 1 == grid.GetLength(0) && r + 1 < grid.GetLength(1))
                            {
                                ShapeBatch.Box(grid[c, r + 1].Rect, new Color(Color.Red, 0.02f));
                            }
                            if (r + 1 == grid.GetLength(1) && c + 1 < grid.GetLength(0))
                            {
                                ShapeBatch.Box(grid[c + 1, r].Rect, new Color(Color.Red, 0.02f));
                            }
                        }
                        else
                        {
                            //array of selected area
                            GridBox[] area = new GridBox[4] { grid[c, r], grid[c + 1, r], grid[c, r + 1], grid[c + 1, r + 1] };

                            if (area[0].IsFilled || area[1].IsFilled || area[2].IsFilled || area[3].IsFilled)
                            {
                                //space is already filled up!
                                foreach (GridBox box in area)
                                {
                                    if (box.IsFilled)
                                    {
                                        ShapeBatch.Box(box.Rect, new Color(Color.Red, 0.02f));
                                    }
                                    else
                                    {
                                        ShapeBatch.Box(box.Rect, new Color(Color.Green, 0.02f));
                                    }
                                }
                            }
                            else
                            {
                                //everything is cool bro
                                ShapeBatch.Box(area[0].Rect, new Color(Color.Green, 0.02f));
                                ShapeBatch.Box(area[1].Rect, new Color(Color.Green, 0.02f));
                                ShapeBatch.Box(area[2].Rect, new Color(Color.Green, 0.02f));
                                ShapeBatch.Box(area[3].Rect, new Color(Color.Green, 0.02f));

                                // Need to draw towers here based on switch. might have to do something different though not sure yet
                                switch (tower)
                                {
                                    case TowerType.Cannon:

                                        break;

                                    case TowerType.Catapult:

                                        break;

                                    case TowerType.Fire:

                                        break;
                                }

                                //all is confirmed, can draw here
                                validPlacement = true;
                            }
                        }
                    }
                    else
                    {
                        ShapeBatch.BoxOutline(grid[c, r].Rect, new Color(Color.Black, 0.1f));
                    }
                    

                }
            }
        }

        public void DrawPath(SpriteBatch sb)
        {
            for (int c = 0; c < grid.GetLength(0); c++)
            {
                for (int r = 0; r < grid.GetLength(1); r++)
                {
                    if (grid[c, r].PathTexture != null)
                    {
                        grid[c, r].IsFilled = true;
                        sb.Draw(grid[c, r].PathTexture, grid[c, r].Rect, null, Color.White, grid[c, r].Rotation, new Vector2(0, 0), grid[c, r].Flip, 1f);
                    }
                }
            }
            
        }

        /// <summary>
        /// returns the position of the box that contains the mouse when clicked
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        public Vector2 GetClickedPosition(MouseState mouse)
        {
            Vector2 position = default;
            for (int c = 0; c < 16; c++)
            {
                for (int r = 0; r < 28; r++)
                {
                    if (grid[c, r].Contains(mouse.Position) && validPlacement)
                    {
                        position = new Vector2(grid[c, r].X, grid[c, r].Y);

                        //returning valid position -> indicate that this grid has been filled
                        grid[c, r].IsFilled = true;
                        grid[c + 1, r].IsFilled = true;
                        grid[c, r + 1].IsFilled = true;
                        grid[c + 1, r + 1].IsFilled = true;
                    }
                }
            }
            return position;
        }

        /// <summary>
        /// resets all filled status except for home base area
        /// </summary>
        public void Reset()
        {
            foreach(GridBox box in grid)
            {
                box.IsFilled = false;
            }

            //setting home base area as filled
            for (int c = 5; c < 11; c++)
            {
                for (int r = 0; r < 3; r++)
                {
                    grid[c, r].IsFilled = true;
                }
            }

            //crab area is filled
            for(int c = 0; c < grid.GetLength(0); c++)
            {
                for(int r = 26; r < grid.GetLength(1); r++)
                {
                    grid[c, r].IsFilled = true;
                }
            }
        }
    }
}
