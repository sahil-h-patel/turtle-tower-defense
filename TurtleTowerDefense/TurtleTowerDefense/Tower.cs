﻿// Zay Arriaga
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
        protected Rectangle hitbox;
        protected Vector2 center;
        protected Crab target;

        /// <summary>
        /// Gets the cost of a tower, or sets it to a new value
        /// </summary>
        public int Cost { get { return bCost; } set { bCost = value; } }

        public Vector2 Center { get { return center; } }

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
            sb.Draw(image, hitbox, Color.White);
        }

        /// <summary>
        /// Takes in a list of crabs and checks if any of them are within range for attacking
        /// </summary>
        /// <param name="crabList"></param>
        public void CheckForTargets(List<Crab> crabList, GameTime gt)
        {
            // If the current tower's target is null, search for a target.
            if (target == null)
            {
                foreach (Crab crab in crabList)
                {
                    double distance = Math.Sqrt(Math.Pow((crab.X - center.X), 2) + Math.Pow((crab.Y - center.Y), 2));

                    if (distance > this.bDetectionRadius && target == null)
                    {
                        target = crab;
                    }
                }
            }
            // Otherwise, attack the crab!
            else
            {
                double tAttackCooldown = bAttackCooldown; // temporary variable so cooldown can be reset
                tAttackCooldown -= gt.ElapsedGameTime.TotalSeconds;

                // Damage crab if cooldown is 0
                if (bAttackCooldown <= 0)
                {
                    target.Health -= bDamage;
                    tAttackCooldown = bAttackCooldown;
                }

            }
        }
    }
}