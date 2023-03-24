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

        public Crab(Texture2D image)
        {
            this.image = image;
            alive = true;
        }

        // A method to detect its current position which will be used in Update to adjust appropiate values

        public void Draw(SpriteBatch sb, int x, int y)
        {
            sb.Draw(image, new Rectangle(x, y, 20*spaceTaken, 20*spaceTaken), Color.White);
        }

        //public void Update(GameTime gT, GraphicsDeviceManager g)
        //{
            
        //}
    }
}
