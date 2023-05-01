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

        public FlameShot Bullet;
        private Texture2D bulletTexture;
        public List<FlameShot> bullets;

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
            bDamage = 1; // base damage of tower
            bAttackCooldown = 0.5; // seconds between each attack, stored as a double
            tAttackCooldown = bAttackCooldown;
            widthOfSingleSprite = 100;
            hitbox = new Rectangle(x, y, widthOfSingleSprite, image.Height);
            center = new Vector2(x + hitbox.Width / 2, y + hitbox.Height / 2);
            this.bulletTexture = bulletTexture;
            Bullet = new FlameShot(bulletTexture, new Rectangle(0, 0, 160, 160));
            bullets = new List<FlameShot>();
        }

        public override void CheckForTargets(List<Crab> crabList, GameTime gt)
        {
            // Cooldown is always ticking down
            tAttackCooldown -= gt.ElapsedGameTime.TotalSeconds;

            //check if any bullets have hit a crab
            foreach (FlameShot b in bullets)
            {
                foreach (Crab crab in crabList)
                {
                    if (b.IsHit(crab))
                    {
                        crab.TakeFireDamage(gt, bDamage);
                    }
                }
            }

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
                rotation = (float)Math.Atan2((double)target.Y - (double)hitbox.Y, (double)target.X - (double)hitbox.X) + 0.15f;
                double distance = Math.Sqrt(Math.Pow((target.X - center.X), 2) + Math.Pow((target.Y - center.Y), 2));

                // Damage crab if cooldown is 0
                if (tAttackCooldown <= 0)
                {
                    //make a bullet and shoot it
                    var bullet = Bullet.Clone() as FlameShot;
                    bullet.Direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
                    bullet.Position = center;
                    bullets.Add(bullet);



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

        /// <summary>
        /// updates bullet information
        /// </summary>
        public override void Update(GameTime gt)
        {
            foreach (FlameShot bullet in bullets)
            {
                bullet.Update(gt);
            }
        }

        public override void Draw(SpriteBatch sb, GameTime gT, GraphicsDevice gD, bool debug)
        {
            foreach (FlameShot bullet in bullets)
            {
                bullet.Draw(sb, gD, rotation, debug);
            }

            base.Draw(sb, gT, gD, debug);

        }

    }
}
