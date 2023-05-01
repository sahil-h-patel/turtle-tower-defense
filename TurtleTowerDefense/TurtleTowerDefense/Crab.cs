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
        protected int[] currentLocation;
        protected double xVelo;
        protected double yVelo;
        protected float rotation;
        private double bDamageTimer;
        private double tDamageTimer;

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

        /// <summary>
        /// Sets or returns the x velocity of the crab
        /// </summary>
        public double XVelo { get { return xVelo; } set { xVelo = value; } }

        /// <summary>
        /// Sets or returns the y velocity of the crab
        /// </summary>
        public double YVelo { get { return yVelo; } set { yVelo = value; } }

        /// <summary>
        /// Returns the speed of the crab
        /// </summary>
        public double Speed { get { return speed; } }

        /// <summary>
        /// Returns or sets the rotation of the crab
        /// </summary>
        public float Rotation { get { return rotation; } set { rotation = value; } }

        /// <summary>
        /// Returns the attacked boolean
        /// </summary>
        public bool Attacked { get { return attacked; } set { attacked = value; } }

        public double DamageTimer { get { return tDamageTimer; } set { tDamageTimer = value; } }


        /// <summary>
        /// Gets the width of one sprite
        /// </summary>
        public int WidthOfSingleSprite { get { return widthOfSingleSprite; } }

        public int[] CurrentLocation { get { return currentLocation; } set { currentLocation = value; } }

        public Crab(Texture2D image, int[] currentLocation, int x, int y)
        {
            this.image = image;
            alive = true;
            xVelo = speed;
            this.currentLocation = currentLocation;
            bDamageTimer = 0.3;
            tDamageTimer = bDamageTimer;
        }

        // A method to detect its current position which will be used in Update to adjust appropiate values

        public void Draw(SpriteBatch sb)
        {
            if (attacked)
            {
                sb.Draw(image, new Rectangle(hitbox.X + widthOfSingleSprite / 2 - 10, hitbox.Y + widthOfSingleSprite / 2 - 10, 40 * spaceTaken, 40 * spaceTaken), new Rectangle(widthOfSingleSprite, 0, widthOfSingleSprite, image.Height), Color.Red, rotation, new Vector2(WidthOfSingleSprite / 2, WidthOfSingleSprite / 2), SpriteEffects.None, 0f);
            }
            else
            {
                sb.Draw(image, new Rectangle(hitbox.X + widthOfSingleSprite / 2 - 10, hitbox.Y + widthOfSingleSprite / 2  - 10, 40 * spaceTaken, 40 * spaceTaken), new Rectangle(0, 0, widthOfSingleSprite, image.Height), Color.White, rotation, new Vector2(WidthOfSingleSprite / 2, WidthOfSingleSprite / 2), SpriteEffects.None, 0f);
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
        }

    }
}
