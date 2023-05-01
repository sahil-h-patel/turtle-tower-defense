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
        /// <summary>
        /// Creates a new flameshot object
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="hitbox"></param>
        public SeaweedBall(Texture2D texture, Rectangle hitbox) : base(texture, hitbox)
        {
            this.texture = texture;
            linearVelocity = 15f;
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

            position += direction * linearVelocity;
            hitBox.X = (int)position.X;
            hitBox.Y = (int)position.Y;
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
                isRemoved = true;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
