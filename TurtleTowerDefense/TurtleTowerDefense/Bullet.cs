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
        private Texture2D texture;
        private float timer;
        private Vector2 position;
        private Vector2 direction;
        private float linearVelocity;
        private float lifespan;
        private bool isRemoved;
        private Rectangle hitBox;

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

        public Bullet(Texture2D texture)
        {
            this.texture = texture;
            linearVelocity = 30f;
            lifespan = 2f;
            isRemoved = false;
            hitBox = new Rectangle(0, 0, 30, 30);
        }

        /// <summary>
        /// updates tgis bullet's timer and position
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
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
        public bool IsHit(Crab target)
        {
            if (target.Hitbox.Intersects(hitBox))
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
        public void Draw(SpriteBatch sb, GraphicsDevice gD)
        {
            if (!isRemoved)
            {
                sb.Draw(texture, new Rectangle((int)position.X - 10, (int)position.Y - 10, 20, 20), Color.White);
                sb.End();
                ShapeBatch.Begin(gD);
                ShapeBatch.BoxOutline(this.hitBox, Color.Black);
                ShapeBatch.End();
                sb.Begin();
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
