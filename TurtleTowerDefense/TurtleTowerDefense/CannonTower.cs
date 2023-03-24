using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    internal class CannonTower : Tower
    {

        /// <summary>
        /// Creates a new cannon tower object, and intializes all of it's data
        /// </summary>
        /// <param name="image"></param>
        /// <param name="hitbox"></param>
        public CannonTower(Texture2D image, int x, int y) : base (image)
        {
            //upgradeTree = 
            detectionRadius = 20.0; // sets detection radius of cannon tower
            spaceTaken = 2; // Sets space taken by tower. 2x2
            cost = 50; // sets cost of the tower
            damage = 5; // base damage of tower
            attacksPerSec = 1; // how many attacks occur per second
            hitbox = new Rectangle(x, y, 20 * spaceTaken, 20 * spaceTaken);

        }


    }
}
