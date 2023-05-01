using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TurtleTowerDefense
{
    internal class ResetWave
    {
        protected List<Tower> towers;
        protected Rectangle hitbox;
        protected Texture2D image;
        protected bool active;
        private Vector2 position;
        private bool movingLeft;
        private List<int> randomLevelChooser;
        private int currentLevel;
        private int bWaveTimer;
        private int waveTimer;

        public bool Active { set { active = value; } }
        private int X { get { return hitbox.X; } set { hitbox.X = value; } }
        private int Y { get { return hitbox.Y; } set { hitbox.Y = value; } }
        /// <summary>
        /// Returns or sets the wave timer
        /// </summary>
        public int WaveTimer { get { return waveTimer; } set{ waveTimer = value; } }

        public ResetWave(Texture2D image, Rectangle hitbox, List<Tower> towers, int waveTimer)
        {
            this.currentLevel = 0;
            this.image = image;
            this.hitbox = hitbox;
            this.towers = towers;
            active = false;
            movingLeft = false;
            randomLevelChooser = new List<int>();
            this.bWaveTimer = waveTimer;
        }



        /// <summary>
        /// Removes the towers from the map in a seamless way
        /// </summary>
        /// <param name="towers"></param>
        public void RemoveTower(List<Tower> towers)
        {
            for (int i = 0; i < towers.Count; i++)
            {
                if (X < towers[i].Hitbox.X)
                {
                    towers.Remove(towers[i]);
                }
            }
        }

        /// <summary>
        /// Updates the wave's position n stuff
        /// </summary>
        /// <param name="g"></param>
        /// <param name="level"></param>
        /// <param name="updatedTowers"></param>
        public void Update(GraphicsDeviceManager g, Level level, List<Tower> updatedTowers, BattleState gameState)
        {
            // Updates towers so that it can remove the correct amount of towers
            towers = updatedTowers;
            if (active)
            {
                // Moves the wave to the left
                if (movingLeft)
                {
                    X -= 15;
                    RemoveTower(towers);
                }

                // Wave recedes back(moves to the right)
                if (X <= 0 || movingLeft == false)
                {
                    movingLeft = false;
                    X += 15;
                    if (X > g.PreferredBackBufferWidth)
                    {
                        active = false;
                        movingLeft = true;
                        waveTimer = bWaveTimer;
                        gameState = BattleState.Setup;
                    }
                }
            }
        }

        /// <summary>
        /// Fills up a list of randomly ordered numbers that are only as long as the current map
        /// </summary>
        /// <param name="path"></param>
        public void FillLevelList(string path)
        {
            // This will fill up a list of ints for choosing random levels. This way we can easily move through the list
            // Using the indexer to get the next level.
            Random rng = new Random();
            int generatedNum;
            for (int i = 0; i < Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length; i++)
            {
                generatedNum = rng.Next(0, Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length);
                while (randomLevelChooser.Contains(generatedNum))
                {
                    generatedNum = rng.Next(0, Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length);
                }
                randomLevelChooser.Add(generatedNum);
            }
        }

        /// <summary>
        /// This will load up the chosen level to the grid
        /// </summary>
        /// <param name="path"></param>
        /// <param name="grid"></param>
        public void ChooseLevel(string path, ref Level level, Grid grid)
        {
            level.Load(path + $"level{randomLevelChooser[currentLevel]}" + ".PATH", grid);
            if (currentLevel == Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Length)
            {
                currentLevel = 0;
            }
            else
            {
                currentLevel++;
            }
        }

        /// <summary>
        /// This will reset all the variables inside this object- not reset the actual map!!!
        /// </summary>
        public void ResetAll()
        {
            currentLevel = 0;
        }

        /// <summary>
        /// Draws the wave
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            if (active)
            {
                sb.Draw(image, new Rectangle(X, Y, hitbox.Width, hitbox.Height), Color.White);
            }
        }

    }
}
