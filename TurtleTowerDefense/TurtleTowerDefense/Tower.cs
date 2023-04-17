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
        protected double bDetectionRadius;
        protected int bSpaceTaken;
        protected int bCost;
        protected int bDamage;
        protected double bAttackCooldown;
        protected double tAttackCooldown;
        protected Rectangle hitbox;
        protected Vector2 center;
        protected Crab target;
        protected int widthOfSingleSprite;


        /// <summary>
        /// Gets the cost of a tower, or sets it to a new value
        /// </summary>
        public int Cost { get { return bCost; } set { bCost = value; } }

        /// <summary>
        /// Returns the center of the turtle. Helpful for debugging and equations
        /// </summary>
        public Vector2 Center { get { return center; } }

        /// <summary>
        /// Returns the base detection radius of the tower
        /// </summary>
        public double BaseDetectionRadius { get { return bDetectionRadius; } }

        /// <summary>
        /// Returns the width of a single sprite on the sprite sheet
        /// </summary>
        public int WidthOfSingleSprite { get { return widthOfSingleSprite; } }

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
        public void Draw(SpriteBatch sb)
        {
            if (tAttackCooldown == bAttackCooldown)
            {
                sb.Draw(image, new Rectangle(hitbox.X, hitbox.Y, 40 * bSpaceTaken, 40 * bSpaceTaken), new Rectangle(0, 0, widthOfSingleSprite + 20, image.Height), Color.White);
            }
            else if (tAttackCooldown > bAttackCooldown * 0.66)
            {
                sb.Draw(image, new Rectangle(hitbox.X, hitbox.Y, 40 * bSpaceTaken, 40 * bSpaceTaken), new Rectangle((widthOfSingleSprite * 1) + 20, 0, widthOfSingleSprite + 20, image.Height), Color.White);

            }
            else if (tAttackCooldown < bAttackCooldown * 0.66)
            {
                sb.Draw(image, new Rectangle(hitbox.X, hitbox.Y, 40 * bSpaceTaken, 40 * bSpaceTaken), new Rectangle((widthOfSingleSprite * 2) + 40, 0, widthOfSingleSprite + 20, image.Height), Color.White);

            }
            else if (tAttackCooldown < bAttackCooldown * 0.33)
            {
                sb.Draw(image, new Rectangle(hitbox.X, hitbox.Y, 40 * bSpaceTaken, 40 * bSpaceTaken), new Rectangle((widthOfSingleSprite * 3) + 60, 0, widthOfSingleSprite + 20, image.Height), Color.White);

            }
        }

        /// <summary>
        /// Takes in a list of crabs and checks if any of them are within range for attacking
        /// </summary>
        /// <param name="crabList"></param>
        public void CheckForTargets(List<Crab> crabList, GameTime gt)
        {

            // Cooldown is always ticking down
            tAttackCooldown -= gt.ElapsedGameTime.TotalSeconds;

            // If the current tower's target is null, search for a target.
            if (target == null)
            {
                foreach (Crab crab in crabList)
                {
                    double distance = Math.Sqrt(Math.Pow((crab.X - center.X), 2) + Math.Pow((crab.Y - center.Y), 2));

                    if (distance <= this.bDetectionRadius && target == null)
                    {
                        target = crab;
                    }
                }
            }
            // Otherwise, attack the crab!
            else
            {
                double distance = Math.Sqrt(Math.Pow((target.X - center.X), 2) + Math.Pow((target.Y - center.Y), 2));

                // Damage crab if cooldown is 0
                if (tAttackCooldown <= 0)
                {
                    target.Health -= bDamage;
                    // If the target just died, set target as null
                    if (target.Health <= 0)
                    {
                        target = null;
                    }
                    tAttackCooldown = bAttackCooldown;
                }
                // Sets to target to null if out of range
                if (distance > this.bDetectionRadius)
                {
                    target = null;
                }

            }
        }
    }
}