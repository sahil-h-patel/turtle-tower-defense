// Zay Arriaga
// This is the Game Object class. It's main purpose is to act as a parent class to the Crab and Tower classes.
// Most of what is in this class is made to be overriden.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    internal class GameObject
    {
        // Fields
        protected Texture2D image;
        protected Rectangle hitbox;

        // Constructor
        public GameObject(Texture2D image, Rectangle hitbox)
        {
            this.image = image;
            this.hitbox = hitbox;
        }

        /// <summary>
        /// Exists only to be overriden
        /// </summary>
        /// <param name="gT"></param>
        /// <param name="g"></param>
        public virtual void Update(GameTime gT, GraphicsDeviceManager g)
        { }

        /// <summary>
        /// Draws the game object, can be overriden by a child class
        /// </summary>
        /// <param name="sb"></param>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(image, 
               hitbox, 
               Color.White);
        }




    }
}
