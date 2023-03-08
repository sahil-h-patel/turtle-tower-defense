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
        public CannonTower(Texture2D image, Rectangle hitbox) : base (image, hitbox)
        {
            //upgradeTree = 
            detectionRadius = 20.0; // sets detection radius of cannon tower
            spaceTaken = new int[2] { 2, 2 }; // Sets space taken by tower. 2x2
            cost = 50; // sets cost of the tower
            this.hitbox = new Rectangle(hitbox.X, hitbox.Y, hitbox.Width * spaceTaken[0], hitbox.Height * spaceTaken[1]);

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(image, hitbox, Color.White);
        }


    }
}
