using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    internal class Wave : GameObject
    {
        protected Rectangle hitbox;
        protected List<Tower> towers;
        protected Texture2D image;
        protected bool active;

        Wave(Texture2D image, Rectangle hitbox, List<Tower> towers) :base(image)
        {
            this.image = image;
            this.hitbox = hitbox;
            this.towers = towers;
            active = false;
        }

        public void RemoveTower(List<Tower> towers)
        {
            foreach (Tower tower in towers)
            {
                if (hitbox.Intersects(tower.Hitbox))
                {
                    towers.Remove(tower);
                }
            }
        }

        public override void Update(GameTime gt, GraphicsDeviceManager g)
        {
            if (active)
            {
                // Moves the wave to the left and should recede back removing towers
                while (X != 0)
                {
                    X -= 5;
                    RemoveTower(towers);
                }
                while(X == g.PreferredBackBufferWidth)
                {
                    X += 5;
                }
                

            }
            base.Update(gt, g);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(image, hitbox, Color.White);
            base.Draw(sb);
        }
    }
}
