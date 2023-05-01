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
    internal class Bullet : ICloneable
    {
        protected Texture2D texture;
        protected float timer;
        protected Vector2 position;
        protected Vector2 direction;
        protected float linearVelocity;
        protected float lifespan;
        protected bool isRemoved;
        protected Rectangle hitBox;
        protected float bRotation;

        public Vector2 Position
        {
            set { position = value; }
        }

        public Vector2 Direction
        {
            set { direction = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
        }
        /// <summary>
        /// Returns or sets the isRemoved boolean
        /// </summary>
        public bool IsRemoved { get { return isRemoved; } set { isRemoved = value; } }

        public Bullet(Texture2D texture, Rectangle hitbox)
        {
            this.texture = texture;
            linearVelocity = 50f;
            lifespan = 2f;
            isRemoved = false;
            this.hitBox = hitbox;
            this.hitBox.X += 15;
            this.hitBox.Y += 15;
            bRotation = default;
        }

        /// <summary>
        /// updates tgis bullet's timer and position
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
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
        public virtual bool IsHit(Crab target)
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

        /// <summary>
        /// draws bullet on screen
        /// </summary>
        /// <param name="sb"></param>
        public virtual void Draw(SpriteBatch sb, GraphicsDevice gD, float rotation, bool debug)
        {
            if (!isRemoved)
            {
                if (bRotation == default)
                {
                    bRotation = rotation;
                }
                sb.Draw(texture, new Rectangle((int)position.X - 10, (int)position.Y - 10, hitBox.Width, hitBox.Height), null, Color.White, bRotation, new Vector2(texture.Width/2, texture.Height/2), SpriteEffects.None, 0f);
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
        /// <summary>
        /// allows this bullet to be cloned
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
