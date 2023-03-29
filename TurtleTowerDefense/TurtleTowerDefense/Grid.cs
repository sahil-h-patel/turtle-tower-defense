
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
    internal class Grid : Game
    {
        private Rectangle[,] grid;
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
            boxWidth = 40;
            boxHeight = 40;

            //initially makes the grid invisible
            isVisible = false;
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
                    grid[c, r] = new Rectangle(boxWidth * r, boxHeight * c, boxWidth, boxHeight);
                }
            }
        }

        /// <summary>
        /// draws grid, highlights where the mouse is hovering over
        /// </summary>
        public void DrawGrid(MouseState mouse)
        {
            for (var c = 0; c < grid.GetLength(0); c++)
            {
                for (int r = 0; r < grid.GetLength(1); r++)
                {
                    //check if mouse is hovering over box
                    if (grid[c, r].Contains(mouse.Position))
                    {
                        ShapeBatch.BoxOutline(grid[c, r], Color.Green);
                    }
                    else
                    {
                        ShapeBatch.BoxOutline(grid[c, r], Color.Black);
                    }

                }
            }
        }
    }
}
