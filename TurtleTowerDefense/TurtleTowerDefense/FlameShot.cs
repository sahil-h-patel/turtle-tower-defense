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
    internal class FlameShot : Bullet
    {
        /// <summary>
        /// Creates a new flameshot object
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="hitbox"></param>
        public FlameShot(Texture2D texture, Rectangle hitbox) : base(texture, hitbox)
        {
            this.texture = texture;
            linearVelocity = 0.25f;
            lifespan = 0.5f;
            isRemoved = false;
            this.hitBox = hitbox;

            timer = 0f;
        }

        /// <summary>
        /// updates tgis bullet's timer and position
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Just moves the intial position of the shot
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
            hitBox.X = (int)position.X - 75;
            hitBox.Y = (int)position.Y - 75;
        }

        /// <summary>
        /// returns whether this bullet hit a crab
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public override bool IsHit(Crab target)
        {
            if (target.Hitbox.Intersects(hitBox) && !IsRemoved)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public override void Draw(SpriteBatch sb, GraphicsDevice gD, float rotation, bool debug)
        {
            if (!isRemoved)
            {
                if (bRotation == default)
                {
                    bRotation = rotation;
                }
                if (timer != 0)
                {
                    sb.Draw(texture, new Rectangle((int)position.X - 10, (int)position.Y - 10, hitBox.Width, hitBox.Height/2), null, Color.White, bRotation, new Vector2(texture.Width/2, texture.Height/2), SpriteEffects.None, 0f);
                }
                if (debug)
                {
                    sb.End();
                    ShapeBatch.Begin(gD);
                    ShapeBatch.BoxOutline(this.hitBox, Color.Black);
                    ShapeBatch.End();
                    sb.Begin();
                }
            }
        }



    }
}
