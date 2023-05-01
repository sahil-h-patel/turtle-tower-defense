using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShapeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    internal class SeaweedBall : Bullet
    {
        private Texture2D deployTexture;
        private Texture2D bulletTexture;
        /// <summary>
        /// Creates a new flameshot object
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="hitbox"></param>
        public SeaweedBall(Texture2D bulletTexture, Texture2D deployTexture, Rectangle hitbox) : base(bulletTexture, hitbox)
        {
            this.texture = bulletTexture;
            this.bulletTexture = bulletTexture;
            this.deployTexture = deployTexture;
            linearVelocity = 80f;
            lifespan = 2f;
            isRemoved = false;
            this.hitBox = hitbox;
        }

        /// <summary>
        /// updates tgis bullet's timer and position
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (timer == 0f)
            {
                position += direction * 85f;
            }
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (timer > lifespan)
            {
                isRemoved = true;
            }

            // Will only update position if it's a bullet
            if (texture == bulletTexture)
            {
                position += direction * linearVelocity;
                hitBox.X = (int)position.X;
                hitBox.Y = (int)position.Y;
            }
        }

        /// <summary>
        /// returns whether this bullet hit a crab
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override bool IsHit(Crab target)
        {
            if (target.Hitbox.Intersects(hitBox) && !isRemoved)
            {
                if (texture == bulletTexture)
                {
                    lifespan = 4f;
                    texture = deployTexture;
                    hitBox.X -= deployTexture.Width/2;
                    hitBox.Y -= deployTexture.Height;
                    hitBox.Width = deployTexture.Width;
                    hitBox.Height = deployTexture.Height;
                }
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
