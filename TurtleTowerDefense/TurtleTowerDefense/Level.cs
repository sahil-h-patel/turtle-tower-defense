using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeUtils;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

//HOW TO USE:
// First, create a new Level object (though I should already have this.)
// Then, when you want to change the level, call the Load method. This will overwrite the path to be taken.
// should be ok from there! :)
namespace TurtleTowerDefense
{
    enum CrabMotion
    {
        None = 00,
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
        Stop = 60,
    }

    internal class Level
    {
        Texture2D straightPathTexture;
        Texture2D turnPathTexture;

        /// <summary>
        /// Creates a new object that stores the pathing
        /// </summary>
        public Level(Texture2D straightPathTexture, Texture2D turnPathTexture)
        {
            this.straightPathTexture = straightPathTexture;
            this.turnPathTexture = turnPathTexture;
        }

        /// <summary>
        /// Loads a new path from a file
        /// </summary>
        public void Load(string filepath, Grid grid)
        {
            try
            {
                string[] pData = new string[31];
                StreamReader input = new StreamReader(filepath);
                string line = null;
                int row = 0;

                // Adds all data from the file into a 2d array
                while ((line = input.ReadLine()!) != null)
                {
                    pData = line.Split(", ");
                    // The data is split by commas so that information can be accessed 
                    for (int i = row; i < grid.GridBoxes.GetLength(0);)
                    {
                        for (int j = 0; j < grid.GridBoxes.GetLength(1); j++)
                        {
                            grid.GridBoxes[i, j].CrabPathing = (CrabMotion)int.Parse(pData[j]);
                            // Sets the correct texture to the grid with the rotation
                            // and whether it needs to be flipped (only applied to turns)
                            switch(grid.GridBoxes[i, j].CrabPathing)
                            {
                                case CrabMotion.None:
                                    grid.GridBoxes[i, j].PathTexture = null;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(0f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.ForwardNorth:
                                    grid.GridBoxes[i, j].PathTexture = straightPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(180f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.ForwardEast:
                                    grid.GridBoxes[i, j].PathTexture = straightPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(0f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.ForwardSouth:
                                    grid.GridBoxes[i, j].PathTexture = straightPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(90f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.ForwardWest:
                                    grid.GridBoxes[i, j].PathTexture = straightPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(180f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.TurnLeftNorth:
                                    grid.GridBoxes[i, j].PathTexture = turnPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(90f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.FlipVertically;
                                    break;
                                case CrabMotion.TurnLeftEast:
                                    grid.GridBoxes[i, j].PathTexture = turnPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(180f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.FlipVertically;
                                    break;
                                case CrabMotion.TurnLeftSouth:
                                    grid.GridBoxes[i, j].PathTexture = turnPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(270f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.FlipVertically;
                                    break;
                                case CrabMotion.TurnLeftWest:
                                    grid.GridBoxes[i, j].PathTexture = turnPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(0f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.FlipVertically;
                                    break;
                                case CrabMotion.TurnRightNorth:
                                    grid.GridBoxes[i, j].PathTexture = turnPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(270f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.TurnRightEast:
                                    grid.GridBoxes[i, j].PathTexture = turnPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(0f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.TurnRightSouth:
                                    grid.GridBoxes[i, j].PathTexture = turnPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(90f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.TurnRightWest:
                                    grid.GridBoxes[i, j].PathTexture = turnPathTexture;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(90f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.Start:
                                    grid.GridBoxes[i, j].PathTexture = null;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(0f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                                case CrabMotion.Stop:
                                    grid.GridBoxes[i, j].PathTexture = null;
                                    grid.GridBoxes[i, j].Rotation = MathHelper.ToRadians(0f);
                                    grid.GridBoxes[i, j].Flip = SpriteEffects.None;
                                    break;
                            }
                        }
                        break;
                    }
                    row++;
                }
                input.Close();

                System.Diagnostics.Debug.WriteLine("BUNCHA STUFF: ");

                for (int i = 0; i < grid.GridBoxes.GetLength(0); i++)
                {
                    for (int k = 0; k < grid.GridBoxes.GetLength(1); k++)
                    {
                        //put a single value
                        System.Diagnostics.Debug.Write(grid.GridBoxes[i, k].CrabPathing);
                    }
                    //next row
                    System.Diagnostics.Debug.WriteLine("");
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

    }
}
