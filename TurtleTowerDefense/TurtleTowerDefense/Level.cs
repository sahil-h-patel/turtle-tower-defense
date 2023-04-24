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

                // Adds all data from the file into a 2d array
                while ((line = input.ReadLine()!) != null)
                {
                    // The data is split by commas so that information can be accessed 
                    for (int i = 0; i < grid.GridBoxes.GetLength(0); i++)
                    {
                        pData = line.Split(", ");
                        for (int j = 0; j < grid.GridBoxes.GetLength(1); j++)
                        {
                            grid.GridBoxes[i, j].CrabPathing = (CrabMotion)int.Parse(pData[j]);
                        }
                    }
                }
                input.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("ERROR: No file with that name. Try something else.");
            }
        }

    }
}
