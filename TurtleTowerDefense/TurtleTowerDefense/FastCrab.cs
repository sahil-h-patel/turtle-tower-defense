using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurtleTowerDefense
{
    internal class FastCrab : Crab
    {
        /// <summary>
        /// Creates a basic, unmodified crab. Bottom of the barrel.
        /// </summary>
        /// <param name="image"></param>
        public FastCrab(Texture2D image, int[] currentLocation, int x, int y) : base(image, currentLocation, x, y)
        {
            health = 4;
            speed = 5;
            spaceTaken = 1;
            hitbox = new Rectangle(x, y, spaceTaken * 40 + 10, spaceTaken * 40 + 10);
            widthOfSingleSprite = 100;
        }
    }
}
