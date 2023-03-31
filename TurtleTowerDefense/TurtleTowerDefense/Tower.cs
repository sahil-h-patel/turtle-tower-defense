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
    internal class Tower
    {

        // Fields
        //protected UpgradeTree upgradeTree;
        protected Texture2D image;
        protected double detectionRadius;
        protected int spaceTaken;
        protected int cost;
        protected double damage;
        protected double attacksPerSec;
        protected Rectangle hitbox;
        protected Crab target;

        /// <summary>
        /// Gets the cost of a tower, or sets it to a new value
        /// </summary>
        public int Cost { get { return cost; } set { cost = value; } }

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
        public Tower(Texture2D image)
        {
            this.image = image;
        }

        /// <summary>
        /// Draws a tower
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void PlaceTower(SpriteBatch sb, int x, int y)
        {
            sb.Draw(image, new Rectangle(hitbox.X, hitbox.Y, 40*spaceTaken, 40*spaceTaken), Color.White);
        }

        /// <summary>
        /// Takes in a list of crabs and checks if any of them are within range for attacking
        /// </summary>
        /// <param name="crabList"></param>
        public void CheckForTargets(List<Crab> crabList)
        {
            if (target == null)
            {
                
            }
            else
            { 
                
            }
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
