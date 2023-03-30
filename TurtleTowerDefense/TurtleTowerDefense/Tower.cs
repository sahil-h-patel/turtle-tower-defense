// Zay Arriaga
// Exists to be overriden by other tower classes. Comes with all the basic shared information of a tower

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    internal class Tower : GameObject
    {

        // Fields
        //protected UpgradeTree upgradeTree;
        protected double detectionRadius;
        protected int spaceTaken;
        protected int cost;
        protected double damage;
        protected double attacksPerSec;

        /// <summary>
        /// Creates a new tower object with all the specified attributes
        /// </summary>
        /// <param name="image"></param>
        /// <param name="hitbox"></param>
        /// <param name="upgradeTree"></param>
        /// <param name="detectionRadius"></param>
        /// <param name="spaceRadius"></param>
        /// <param name="cost"></param>
        /// <param name="towerClass"></param>
        public Tower(Texture2D image) : base (image)
        {
        }

        public void PlaceTower(SpriteBatch sb, int x, int y)
        {
            sb.Draw(image, new Rectangle(this.X, this.Y, 40*spaceTaken, 40*spaceTaken), Color.White);
        }

    }

    //internal class Tower : GameObject
    //{

    //    // Fields
    //    private UpgradeTree upgradeTree;
    //    private double detectionRadius;
    //    private int spaceRadius;
    //    private int cost;

    //}
}
