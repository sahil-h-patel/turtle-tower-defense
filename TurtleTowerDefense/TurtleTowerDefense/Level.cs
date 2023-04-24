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

        /// <summary>
        /// Creates a new object that stores the pathing
        /// </summary>
        public Level()
        {
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
