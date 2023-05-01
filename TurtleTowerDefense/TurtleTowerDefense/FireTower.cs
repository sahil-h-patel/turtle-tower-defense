using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    internal class FireTower : Tower
    {

        /// <summary>
        /// Creates a new cannon tower object, and intializes all of it's data
        /// </summary>
        /// <param name="image"></param>
        /// <param name="hitbox"></param>
        public FireTower(Texture2D image, int x, int y, Texture2D bulletTexture) : base(image)
        {
            //upgradeTree = 
            bDetectionRadius = 150.0; // sets detection radius of cannon tower
            bSpaceTaken = 2; // Sets space taken by tower. 2x2
            bCost = 100; // sets cost of the tower
            bDamage = 3; // base damage of tower
            bAttackCooldown = 0.5; // seconds between each attack, stored as a double
            tAttackCooldown = bAttackCooldown;
            widthOfSingleSprite = 100;
            hitbox = new Rectangle(x, y, widthOfSingleSprite, image.Height);
            center = new Vector2(x + hitbox.Width / 2, y + hitbox.Height / 2);
        }


    }
}
