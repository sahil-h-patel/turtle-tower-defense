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

        public Crab(Texture2D image, int x, int y)
        {
            this.image = image;
            alive = true;
            hitbox = new Rectangle(x, y, 20 * spaceTaken, 20 * spaceTaken);
        }

        // A method to detect its current position which will be used in Update to adjust appropiate values

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, hitbox, Color.White);
        }

        //public void Update(GameTime gT, GraphicsDeviceManager g)
        //{
            
        //}
    }
}
