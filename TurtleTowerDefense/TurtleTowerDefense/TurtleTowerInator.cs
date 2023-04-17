using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShapeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{

    enum GameState { CutScene, MainMenu, Modes, Settings_Menu, Game, Settings_Game, GameOver }
    enum BattleState { None, Setup, Assault }
    internal class TurtleTowerInator
    {

        // Fields

        // Game Elements
        protected int homeBaseHP;
        protected Rectangle homeBaseRect;
        protected List<Tower> turtleTowers;

        protected Tower defaultCannonTower;

        // Textures
        protected Texture2D cannonTowerTexture;
        protected Texture2D homeBaseTexture;

        public int HomeBaseHP { get { return homeBaseHP; } }

        /// <summary>
        /// Essentially works as intialization. Sets up all fields
        /// and gives them the proper values to start with.
        /// </summary>
        public TurtleTowerInator()
        {
            homeBaseHP = 100;
            homeBaseRect = new Rectangle(0, 240, 120, 240);

            // Sets up lists for towers and crabs
            turtleTowers = new List<Tower>();

        }

        /// <summary>
        /// Loads up content- really just for textures.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            homeBaseTexture = Content.Load<Texture2D>("homebase sprite");
            cannonTowerTexture = Content.Load<Texture2D>("cannon tower sprite");

            // Default cannon tower
            defaultCannonTower = new CannonTower(cannonTowerTexture, -50, -50);
        }

        /// <summary>
        /// If the player clicks on a grid square
        /// </summary>
        public void PlaceTower(Grid buildGrid, ref int seashells, MouseState currentMouseState, MouseState prevMouseState)
        {
            // The purpose for defaultCannonTower is for their cost- might change it to an int later.
            if (seashells >= defaultCannonTower.Cost)
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    Vector2 towerPos = buildGrid.GetClickedPosition(currentMouseState);

                    if (towerPos != default)
                    {
                        turtleTowers.Add(new CannonTower(cannonTowerTexture, (int)towerPos.X, (int)towerPos.Y));
                        seashells -= defaultCannonTower.Cost;

                    }
                }
            }
        }

        /// <summary>
        /// Makes every turtle tower check for targets and deal damage.
        /// </summary>
        /// <param name="crabs"></param>
        /// <param name="gT"></param>
        public void AttackEnemies(List<Crab> crabs, GameTime gT)
        {
            for (int i = 0; i < turtleTowers.Count; i++)
            {
                turtleTowers[i].CheckForTargets(crabs, gT);
            }
        }

        /// <summary>
        /// Draws all the towers on the screen
        /// </summary>
        public void DrawTowers(SpriteBatch sb, GraphicsDevice gD, bool debugMode)
        {

            sb.Draw(homeBaseTexture, homeBaseRect, Color.White);

            for (int i = 0; i < turtleTowers.Count; i++)
            {
                turtleTowers[i].Draw(sb);
                if (debugMode)
                {
                    sb.End();
                    ShapeBatch.Begin(gD);
                    ShapeBatch.CircleOutline(turtleTowers[i].Center, (float)turtleTowers[i].BaseDetectionRadius, Color.Black);
                    ShapeBatch.End();
                    sb.Begin();
                }
            }

        }

        /// <summary>
        /// Resets the turtle tower list
        /// </summary>
        public void Reset()
        {
            turtleTowers.Clear();
            homeBaseHP = 100;
        }

    }
}
