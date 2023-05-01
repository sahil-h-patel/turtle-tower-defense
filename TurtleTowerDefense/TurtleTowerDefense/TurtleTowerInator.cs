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
        protected Texture2D bulletTexture;
        protected Texture2D homeBaseTexture;
        protected Texture2D catapultTowerTexture;
        protected Texture2D fireTowerTexture;

        public List<Tower> Towers { get { return turtleTowers; } }

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
            bulletTexture = Content.Load<Texture2D>("cannon tower sprite");

            // Default cannon tower
            defaultCannonTower = new CannonTower(cannonTowerTexture, -50, -50, bulletTexture);
            defaultCatapultTower = new CatapultTower(catapultTowerTexture, -50, -50, bulletTexture);
            defaultFireTower = new FireTower(fireTowerTexture, -50, -50, bulletTexture);
        }

        /// <summary>
        /// If the player clicks on a grid square
        /// </summary>
        public void PlaceTower(Grid buildGrid, ref int seashells, ref int spentShells, MouseState currentMouseState, MouseState prevMouseState, ref TowerType tower)
        {
            // The purpose for defaultCannonTower is for their cost- might change it to an int later.
            if (seashells >= defaultCannonTower.Cost)
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    Vector2 towerPos = buildGrid.GetClickedPosition(currentMouseState);

                    if (towerPos != default)
                    {
                        switch (tower)
                        {
                            case TowerType.Cannon:
                                turtleTowers.Add(new CannonTower(cannonTowerTexture, (int)towerPos.X, (int)towerPos.Y, bulletTexture));
                                seashells -= defaultCannonTower.Cost;
                                spentShells += defaultCannonTower.Cost;
                                tower = TowerType.None;
                                break;

                            case TowerType.Catapult:
                                turtleTowers.Add(new CatapultTower(catapultTowerTexture, (int)towerPos.X, (int)towerPos.Y, bulletTexture));
                                seashells -= defaultCatapultTower.Cost;
                                spentShells += defaultCatapultTower.Cost;
                                tower = TowerType.None;
                                break;

                            case TowerType.Fire:
                                turtleTowers.Add(new FireTower(fireTowerTexture, (int)towerPos.X, (int)towerPos.Y, bulletTexture));
                                seashells -= defaultFireTower.Cost;
                                spentShells += defaultFireTower.Cost;
                                tower = TowerType.None;
                                break;
                        }
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
                turtleTowers[i].Update(gT);
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
