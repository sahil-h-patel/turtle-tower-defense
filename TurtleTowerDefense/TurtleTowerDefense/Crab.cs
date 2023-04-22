using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    internal class Crab
    {

        protected Texture2D image;
        protected int spaceTaken;
        protected int health;
        protected double speed;
        protected bool alive;
        protected Rectangle hitbox;
        protected int widthOfSingleSprite;
        protected bool attacked;

        /// <summary>
        /// Gets or sets the X value of the crab
        /// </summary>
        public int X { get { return hitbox.X; } set { hitbox.X = value; } }

        /// <summary>
        /// Gets or sets the Y value of the crab
        /// </summary>
        public int Y { get { return hitbox.Y; } set { hitbox.Y = value; } }

        /// <summary>
        /// Returns the image of the crab
        /// </summary>
        public Texture2D Image { get { return image; } }

        /// <summary>
        /// Returns the hitbox of the crab
        /// </summary>
        public Rectangle Hitbox { get { return hitbox; } }

        /// <summary>
        /// Gets or sets the health value
        /// </summary>
        public int Health { get { return health; } set { health = value; } }

        /// <summary>
        /// Gets or sets the alive state
        /// </summary>
        public bool Alive { get { return alive; } set { alive = value; } }

        /// <summary>
        /// Returns the width of the crab
        /// </summary>
        public int Width { get { return spaceTaken * 40; } }

        /// <summary>
        /// Returns the height of the crab
        /// </summary>
        public int Height { get { return spaceTaken * 40; } }

        public int WidthOfSingleSprite { get { return widthOfSingleSprite; } }

        public Crab(Texture2D image, int x, int y)
        {
            this.image = image;
            alive = true;
        }

        // A method to detect its current position which will be used in Update to adjust appropiate values

        public void Draw(SpriteBatch sb)
        {
            if (attacked)
            {
                sb.Draw(image, new Rectangle(hitbox.X, hitbox.Y, spaceTaken * 40, spaceTaken * 40), new Rectangle(100, 0, widthOfSingleSprite * 2 + 20, image.Height), Color.MonoGameOrange);
            }
            else
            {
                sb.Draw(image, new Rectangle(hitbox.X, hitbox.Y, spaceTaken * 40, spaceTaken * 40), new Rectangle(0, 0, widthOfSingleSprite * 2 + 20, image.Height), Color.White);
            }
            
        }

        /// <summary>
        /// crab has taken damage. ouch!
        /// </summary>
        /// <param name="gT"></param>
        /// <param name="damage"></param>
        public void TakeDamage(GameTime gt, int damage)
        {
            health -= damage;
            attacked = true;

            double timer = 0.3;
            timer -= gt.ElapsedGameTime.TotalSeconds;
            if(timer <= 0)
            {
                attacked = false;
            }
        }

        //public void Update(GameTime gT, GraphicsDeviceManager g)
        //{

        //}
    }
}
