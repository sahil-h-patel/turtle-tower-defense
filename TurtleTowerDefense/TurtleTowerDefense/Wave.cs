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
    internal class ResetWave
    {
        protected List<Tower> towers;
        protected Rectangle hitbox;
        protected Texture2D image;
        protected bool active;
        private Vector2 position;

        public ResetWave(Texture2D image, Rectangle hitbox, List<Tower> towers)
        {
            this.image = image;
            this.hitbox = hitbox;
            this.towers = towers;
            active = false;
        }

        public bool Active { set { active = value; } }
        private int X { get { return hitbox.X; } set { hitbox.X = value; } }
        private int Y { get { return hitbox.Y; } set { hitbox.Y = value; } }

        public void RemoveTower(List<Tower> towers)
        {
            for (int i = 0; i < towers.Count; i++)
            {
                if (hitbox.Intersects(towers[i].Hitbox))
                {
                    towers.Remove(towers[i]);
                }
            }
        }

        public void Update(GraphicsDeviceManager g, List<Tower> updatedTowers)
        {
            // Updates towers so that it can remove the correct amount of towers
            towers = updatedTowers;
            if (active)
            {
                // Moves the wave to the left
                while (X != 0)
                {
                    X -= 5;
                    RemoveTower(towers);
                }

                // Wave recedes back(moves to the right)
                while (X != g.PreferredBackBufferWidth)
                {
                    X += 5;
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if (active)
            {
                sb.Draw(image, new Rectangle(X, Y, hitbox.Width, hitbox.Height), Color.White);
            }
        }

    }
}
