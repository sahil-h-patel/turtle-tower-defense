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

    enum GameState { CutScene, MainMenu, Modes, Settings_Menu, Game, Settings_Game, GameOver, Tutorial }
    enum BattleState { None, Setup, Assault, Wave }
    internal class TurtleTowerInator
    {

        // Fields

        // Game Elements
        protected List<Tower> turtleTowers;
        protected Tower defaultCannonTower;
        protected Tower defaultCatapultTower;
        protected Tower defaultFireTower;

        // Textures
        protected Texture2D cannonTowerTexture;
        protected Texture2D cannonBallTexture;
        protected Texture2D catapultTowerTexture;
        protected Texture2D seaweedBall;
        protected Texture2D fireTowerTexture;
        protected Texture2D flameShot;

        /// <summary>
        /// Returns a list of all the turtle towers
        /// </summary>
        public List<Tower> Towers { get { return turtleTowers; } }

        /// <summary>
        /// Returns the cannon tower texture
        /// </summary>
        public Texture2D CannonTowerTexture { get { return cannonTowerTexture; } }
        /// <summary>
        /// Returns the catapult tower texture
        /// </summary>
        public Texture2D CatapultTowerTexture { get { return catapultTowerTexture; } }
        /// <summary>
        /// Returns the fire tower texture
        /// </summary>
        public Texture2D FireTowerTexture { get { return fireTowerTexture; } }

        /// <summary>
        /// Essentially works as intialization. Sets up all fields
        /// and gives them the proper values to start with.
        /// </summary>
        public TurtleTowerInator()
        {
            // Sets up lists for towers and crabs
            turtleTowers = new List<Tower>();
        }

        /// <summary>
        /// Loads up content- really just for textures.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            cannonTowerTexture = Content.Load<Texture2D>("cannon tower sprite");
            catapultTowerTexture = Content.Load<Texture2D>("catapult tower sprite");
            fireTowerTexture = Content.Load<Texture2D>("fire tower sprite");
            cannonBallTexture = Content.Load<Texture2D>("bullet");
            seaweedBall = Content.Load<Texture2D>("seaweed ball");
            flameShot = Content.Load<Texture2D>("fire tower fire");

            // Default cannon tower
            defaultCannonTower = new CannonTower(cannonTowerTexture, -50, -50, cannonBallTexture);
            defaultCatapultTower = new CatapultTower(catapultTowerTexture, -50, -50, seaweedBall);
            defaultFireTower = new FireTower(fireTowerTexture, -50, -50, flameShot);
        }

        /// <summary>
        /// If the player clicks on a grid square
        /// </summary>
        public void PlaceTower(Grid buildGrid, ref int seashells, ref int spentShells, MouseState currentMouseState, MouseState prevMouseState, ref TowerType tower)
        {
            // The purpose for defaultCannonTower is for their cost- might change it to an int later.
            // This is the pricing and checks for a cannon tower
            if (seashells >= defaultCannonTower.Cost && tower == TowerType.Cannon)
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    Vector2 towerPos = buildGrid.GetClickedPosition(currentMouseState);

                    if (towerPos != default)
                    {

                        turtleTowers.Add(new CannonTower(cannonTowerTexture, (int)towerPos.X, (int)towerPos.Y, cannonBallTexture));
                        seashells -= defaultCannonTower.Cost;
                        spentShells += defaultCannonTower.Cost;
                        tower = TowerType.None;
                    }

                }
            }
            // Pricing and checks for a catapult tower
            if (seashells >= defaultCatapultTower.Cost && tower == TowerType.Catapult)
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    Vector2 towerPos = buildGrid.GetClickedPosition(currentMouseState);

                    if (towerPos != default)
                    {

                        turtleTowers.Add(new CatapultTower(catapultTowerTexture, (int)towerPos.X, (int)towerPos.Y, seaweedBall));
                        seashells -= defaultCatapultTower.Cost;
                        spentShells += defaultCatapultTower.Cost;
                        tower = TowerType.None;
                    }

                }
            }
            // This is the pricing and checks for a fire tower
            if (seashells >= defaultFireTower.Cost && tower == TowerType.Fire)
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    Vector2 towerPos = buildGrid.GetClickedPosition(currentMouseState);

                    if (towerPos != default)
                    {

                        turtleTowers.Add(new FireTower(fireTowerTexture, (int)towerPos.X, (int)towerPos.Y, flameShot));
                        seashells -= defaultFireTower.Cost;
                        spentShells += defaultFireTower.Cost;
                        tower = TowerType.None;
                    }

                }
            }
        }

        /// <summary>
        /// Updates the bullets positions
        /// </summary>
        /// <param name="gT"></param>
        public void UpdateBullets(GameTime gT)
        {
            foreach (Tower turtle in turtleTowers)
            {
                turtle.Update(gT);
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
        /// Removes the turtle's targets
        /// </summary>
        public void RemoveTargets()
        {
            foreach (Tower turtle in turtleTowers)
            {
                turtle.Target = null;

            }
        }


        /// <summary>
        /// Draws all the towers on the screen
        /// </summary>
        public void DrawTowers(SpriteBatch sb, GraphicsDevice gD, GameTime gT, bool debugMode)
        {
            MouseState mouse = Mouse.GetState();
            for (int i = 0; i < turtleTowers.Count; i++)
            {
                turtleTowers[i].Draw(sb, gT, gD);
                if (debugMode)
                {
                    sb.End();
                    ShapeBatch.Begin(gD);
                    ShapeBatch.CircleOutline(turtleTowers[i].Center, (float)turtleTowers[i].BaseDetectionRadius, Color.Black);
                    ShapeBatch.End();
                    sb.Begin();
                }
                if (turtleTowers[i].Hitbox.Contains(mouse.X, mouse.Y))
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
        }

    }
}
