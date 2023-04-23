using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

    internal class PathFile
    {
        private StreamReader input = null;
        private FileStream stream;
        private CrabMotion[,] path;
        private int startingX;
        private int startingY;
        private int endingX;
        private int endingY;

        public PathFile(string path)
        {
            stream = new FileStream(path, FileMode.Open);
            input = new StreamReader(stream);
            Load();
        }

        // Loads from file
        // Files only save from within the Editor Solution so you might have to change the path for it directly within the code
        public void Load()
        {
            string line;
            int x = 0;
            while((line = input.ReadLine()) != null)
            {
                int[] moveData = ConvertInt32Array(line.Split(','));
                for (int y = 0; y < moveData.Length; y++)
                {
                    if (moveData[y] == 50)
                    {
                        startingX = x;
                        startingY = y;
                    }
                    else if (moveData[y] == 50)
                    {
                        endingX = x;
                        endingY = y;
                    }
                    path[x, y] = (CrabMotion)moveData[y];

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

        // Not too sure if this works correctly basically checks for the box above, below and next (after it in the x dir) 
        // To see whether there is a valid move and adds it to the list and increases the position for it to be checks again
        public List<CrabMotion> CrabMovesInOrder()
        {
            List<CrabMotion> validMoves = new List<CrabMotion>();
            int x = startingX;
            int y = startingY;

            while (path[x, y] != CrabMotion.Stop)
            {
                if (path[x, y + 1] != CrabMotion.None)
                {
                    validMoves.Add(path[x, y + 1]);
                    y++;
                }
                else if (path[x, y - 1] != CrabMotion.None)
                {
                    validMoves.Add(path[x, y - 1]);
                    y--;
                }
                else if (path[x - 1, y] != CrabMotion.None)
                {
                    validMoves.Add(path[x - 1, y]);
                    x--;
                }
            }
            return validMoves;
        }

        // using tuple return: basically returns multiple values within one ref
        public (int x, int y, float rotation) MotionToValues(CrabMotion cm, int widthOfSprite)
        {
            switch (cm)
            {
                case CrabMotion.None:
                    return (0, 0, 0f);
                case CrabMotion.ForwardNorth:
                    return (widthOfSprite, 0, 90f);
                case CrabMotion.ForwardEast:
                    return (widthOfSprite, 0, 180f);
                case CrabMotion.ForwardSouth:
                    return (widthOfSprite, 0, -90f);
                case CrabMotion.ForwardWest:
                    return (widthOfSprite, 0, 0f);
                case CrabMotion.TurnLeftNorth:
                    return (0, widthOfSprite, 90f);
                case CrabMotion.TurnLeftEast:
                    return (widthOfSprite, 0, 180f);
                case CrabMotion.TurnLeftSouth:
                    return (widthOfSprite, 0, -90f);
                // Still go to do the other cases;
                case CrabMotion.TurnLeftWest:
                case CrabMotion.TurnRightNorth:
                case CrabMotion.TurnRightEast:
                case CrabMotion.TurnRightSouth:
                case CrabMotion.TurnRightWest:
                case CrabMotion.SplitLeftRight:
                case CrabMotion.SplitUpDown:
                case CrabMotion.Start:
                case CrabMotion.Stop:
                    break;
            }
        }
    }
}
