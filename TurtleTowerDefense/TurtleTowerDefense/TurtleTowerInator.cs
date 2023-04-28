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
        protected Texture2D bulletTexutre;
        protected Texture2D homeBaseTexture;
        protected Texture2D catapultTowerTexture;
        protected Texture2D fireTowerTexture;

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
            bulletTexutre = Content.Load<Texture2D>("bullet");
            catapultTowerTexture = Content.Load<Texture2D>("catapult tower sprite");
            fireTowerTexture = Content.Load<Texture2D>("fire tower sprite");

            // Default cannon tower
            defaultCannonTower = new CannonTower(cannonTowerTexture, -50, -50, bulletTexutre);
        }

        /// <summary>
        /// If the player clicks on a grid square
        /// </summary>
        public void PlaceTower(Grid buildGrid, ref int seashells, MouseState currentMouseState, MouseState prevMouseState, ref TowerType tower)
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
                                turtleTowers.Add(new CannonTower(cannonTowerTexture, (int)towerPos.X, (int)towerPos.Y, bulletTexutre));
                                seashells -= defaultCannonTower.Cost;
                                tower = TowerType.None;
                                break;

                            case TowerType.Catapult:
                                turtleTowers.Add(new CatapultTower(catapultTowerTexture, (int)towerPos.X, (int)towerPos.Y));
                                seashells -= defaultCannonTower.Cost;
                                tower = TowerType.None;
                                break;

                            case TowerType.Fire:
                                turtleTowers.Add(new FireTower(fireTowerTexture, (int)towerPos.X, (int)towerPos.Y));
                                seashells -= defaultCannonTower.Cost;
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
        /// Draws all the towers on the screen
        /// </summary>
        public void DrawTowers(SpriteBatch sb, GraphicsDevice gD, GameTime gT, bool debugMode)
        {
            sb.Draw(homeBaseTexture, homeBaseRect, Color.White);
            MouseState mouse = Mouse.GetState();
            for (int i = 0; i < turtleTowers.Count; i++)
            {
                turtleTowers[i].Draw(sb, gT);
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
            homeBaseHP = 100;
        }

    }
}
