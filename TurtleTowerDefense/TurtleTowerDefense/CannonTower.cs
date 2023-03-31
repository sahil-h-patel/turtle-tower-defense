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
            bDetectionRadius = 20.0; // sets detection radius of cannon tower
            bSpaceTaken = 2; // Sets space taken by tower. 2x2
            bCost = 50; // sets cost of the tower
            bDamage = 5; // base damage of tower
            bAttackCooldown = 2; // seconds between each attack, stored as a double
            hitbox = new Rectangle(x, y, 40 * bSpaceTaken, 40 * bSpaceTaken);
            center = new Vector2(x - (hitbox.Width/2), y - (hitbox.Height/2));
        }


    }
}
