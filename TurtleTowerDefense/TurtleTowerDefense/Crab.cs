using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    internal class Crab : GameObject
    {
        public Crab(Texture2D image, Rectangle hitbox) 
            : base(image, hitbox)
        {

        }

        // A method to detect its current position which will be used in Update to adjust appropiate values

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }

        public override void Update(GameTime gT, GraphicsDeviceManager g)
        {
            // Update health
            // Update position
            base.Update(gT, g);
        }
    }
}
