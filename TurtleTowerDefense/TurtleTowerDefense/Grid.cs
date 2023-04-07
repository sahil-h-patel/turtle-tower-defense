
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeUtils;
using Microsoft.Xna.Framework.Input;

namespace TurtleTowerDefense
{
    /// <summary>
    /// handles grid system for tower placement
    /// </summary>
    internal class Grid
    {
        private Rectangle[,] grid;
        private bool[,] isFilled;
        private int boxWidth;
        private int boxHeight;
        private bool isVisible;


        /// <summary>
        /// creates a grid based on given width and height in boxes
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Grid(int width, int height)
        {
            grid = new Rectangle[width, height];
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
                    grid[c, r] = new Rectangle((boxWidth * r), (boxHeight * c) + 80, boxWidth, boxHeight);
                }
            }
        }

        /// <summary>
        /// draws grid, highlights where the mouse is hovering over
        /// </summary>
        public void DrawGrid(MouseState mouse)
        {
            for (int c = 0; c < grid.GetLength(0); c++)
            {
                for (int r = 0; r < grid.GetLength(1); r++)
                {
                    //check if mouse is hovering over box
                    if (grid[c, r].Contains(mouse.Position))
                    {
                        
                        if (c +1 < grid.GetLength(0) && r +1 < grid.GetLength(1))
                        {   ShapeBatch.Box(grid[c, r], new Color(Color.Green, 0.02f));
                            ShapeBatch.Box(grid[c + 1, r], new Color(Color.Green, 0.02f));
                            ShapeBatch.Box(grid[c, r + 1], new Color(Color.Green, 0.02f));
                            ShapeBatch.Box(grid[c + 1, r + 1], new Color(Color.Green, 0.02f));
                        }
                        else
                        {
                            ShapeBatch.Box(grid[c, r], new Color(Color.Red, 0.02f));

                            if(c + 1 == grid.GetLength(0) && r + 1 < grid.GetLength(1))
                            {
                                ShapeBatch.Box(grid[c, r + 1], new Color(Color.Red, 0.02f));
                            }
                            if (r + 1 == grid.GetLength(1) && c + 1 < grid.GetLength(0)) 
                            {
                                ShapeBatch.Box(grid[c + 1, r], new Color(Color.Red, 0.02f));
                            }
                        }

                    }
                    else
                    {
                        ShapeBatch.BoxOutline(grid[c, r], Color.Black);
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
             foreach(Rectangle box in grid)
            {
                if (box.Contains(mouse.Position))
                {
                    position = new Vector2(box.X, box.Y);
                }
            }
             return position;
        }
    }
}
