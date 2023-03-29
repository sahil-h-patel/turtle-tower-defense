﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    enum GameState { CutScene, MainMenu, Modes, Settings_Menu, Game, Settings_Game, GameOver }
    enum InGameState { None, Setup, Assault }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D bgTexture;

        //prototype sprites
        private Texture2D towerProtoTexture;
        private Texture2D crabProtoTexture;
        private SpriteFont comicSans20;

        private GameState currentState;
        private InGameState inGameState;
        private KeyboardState prevKbState;
        private MouseState prevMouseState;
        private double cutsceneTimer;
        private double setupTimer;
        private double basicCrabTimer;

        // Cash for player
        private int seashells;

        // Contains all placed turtle towers
        private List<Tower> turtleTowers;
        // Contains all basicCrabs
        private List<BasicCrab> basicCrabs;
        // Creates default towers for use of values
        private CannonTower defaultCannonTower;

        private int waveCounter;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            currentState = GameState.CutScene;
            inGameState = InGameState.None;
            defaultCannonTower = new CannonTower(towerProtoTexture, -50, -50);
            waveCounter = 1;
            // Sets up timers for game
            cutsceneTimer = 5;
            setupTimer = 15;
            basicCrabTimer = 1;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            turtleTowers = new List<Tower>();
            basicCrabs = new List<BasicCrab>();

            bgTexture = Content.Load<Texture2D>("bg");

            //prototype textures
            towerProtoTexture = Content.Load<Texture2D>("towerProto");
            crabProtoTexture = Content.Load<Texture2D>("crabProto");
            comicSans20 = Content.Load<SpriteFont>("comicSans20");

        }

        /// <summary>
        /// checks if given key was first pressed on this frame
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool SingleKeyPress(Keys key)
        {
            //get current keyboard state
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(key) && prevKbState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState kb = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            //managing game states FSM
            switch (currentState)
            {
                case GameState.MainMenu:
                    // Resets towers and wave counter if values were modified
                    turtleTowers.Clear();
                    waveCounter = 1;
                    //hitting tab goes to main menu settings
                    if (SingleKeyPress(Keys.Tab))
                    {
                        currentState = GameState.Settings_Menu;
                    }
                    //hitting enter goes to modes
                    if (SingleKeyPress(Keys.Enter))
                    {
                        currentState = GameState.Modes;
                    }

                    break;

                case GameState.Settings_Menu:

                    //hitting tab goes back to the main menu
                    if (SingleKeyPress(Keys.Tab))
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;

                case GameState.Modes:

                    //hitting backspace goes back to the main menu
                    if (SingleKeyPress(Keys.Back))
                    {
                        currentState = GameState.MainMenu;
                    }
                    //hitting enter starts game
                    if (SingleKeyPress(Keys.Enter))
                    {
                        currentState = GameState.Game;
                        inGameState = InGameState.Setup;
                        seashells = 100;

                    }

                    break;

                // Begin the game! The game state also has a few game states as well, 
                case GameState.Game:

                    switch (inGameState)
                    {

                        // Allows the player time to place and upgrade towers
                        case InGameState.Setup:
                            basicCrabs.Clear();
                            string timerString = String.Format("{0:0.00}", setupTimer);
                            // Places a tower, if the player has enough cash
                            if (seashells >= defaultCannonTower.Cost)
                            {
                                if (mState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                                {
                                    turtleTowers.Add(new CannonTower(towerProtoTexture, mState.X, mState.Y));
                                    seashells = seashells - turtleTowers[turtleTowers.Count - 1].Cost;
                                }
                            }

                            // If you run out of time setting up, change into assault mode, beginning the crab attack
                            setupTimer -= gameTime.ElapsedGameTime.TotalSeconds;

                            if (setupTimer <= 0)
                            {
                                inGameState = InGameState.Assault;
                            }



                            break;



                        // Begins the crab assault on the turtle base
                        case InGameState.Assault:
                            if (basicCrabs.Count < 1 + waveCounter)
                            {
                                for (int i = 0; i < 1 + waveCounter; i++)
                                {
                                    basicCrabs.Add(new BasicCrab(crabProtoTexture, _graphics.PreferredBackBufferWidth - 10, _graphics.PreferredBackBufferHeight / 2));
                                }
                            }
                            if (basicCrabs.Count == 0)
                            {
                                waveCounter++;
                                inGameState = InGameState.Setup;
                            }
                            // Moves crabs, along with a timer spacing them out from being spawned
                            foreach (Crab crab in basicCrabs)
                            {
                                crab.X -= 2;
                                while (basicCrabTimer > 0)
                                {
                                    basicCrabTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                                }
                            }
                            break;

                    }

                    //hitting tab goes to in-game settings, enter goes to GameOver
                    if (SingleKeyPress(Keys.Tab))
                    {
                        currentState = GameState.Settings_Game;
                    }
                    if (SingleKeyPress(Keys.Enter))
                    {
                        currentState = GameState.GameOver;
                    }

                    break;


                case GameState.Settings_Game:

                    //hitting tab goes back to game
                    if (SingleKeyPress(Keys.Tab))
                    {
                        currentState = GameState.Game;
                    }

                    //hitting backspace goes back to main menu
                    if (SingleKeyPress(Keys.Back))
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;

                case GameState.GameOver:
                    //hitting enter goes to main menu
                    if (SingleKeyPress(Keys.Enter))
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;

                //cutscene ends after playing, goes to main menu afterwards
                case GameState.CutScene:

                    cutsceneTimer -= gameTime.ElapsedGameTime.TotalSeconds;

                    if (cutsceneTimer <= 0)
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;
            }

            prevKbState = kb;
            prevMouseState = mState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            switch (currentState)
            {
                case GameState.MainMenu:

                    _spriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
                    _spriteBatch.DrawString(comicSans20, "This is the Main Menu!", new Vector2(300, 500), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Tab -> Menu Settings", new Vector2(300, 550), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Enter -> Game Modes", new Vector2(300, 600), Color.White);

                    break;

                case GameState.Settings_Menu:

                    _spriteBatch.GraphicsDevice.Clear(Color.MediumBlue);
                    _spriteBatch.DrawString(comicSans20, "This is the Menu Settings", new Vector2(300, 500), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Tab -> Main Menu", new Vector2(300, 550), Color.White);

                    break;

                case GameState.Modes:

                    _spriteBatch.GraphicsDevice.Clear(Color.PeachPuff);
                    _spriteBatch.DrawString(comicSans20, "This is the Game Mode Screen", new Vector2(300, 500), Color.Plum);
                    _spriteBatch.DrawString(comicSans20, "Enter -> Game", new Vector2(300, 550), Color.Plum);
                    _spriteBatch.DrawString(comicSans20, "Backspace -> Main Menu", new Vector2(300, 600), Color.White);

                    break;

                case GameState.Game:
                    //background image
                    _spriteBatch.Draw(bgTexture, new Rectangle(0, 0, 1280, 720), Color.White);

                    //tower sprite place holder
                    _spriteBatch.Draw(towerProtoTexture, new Rectangle(-120, 260, 250, 250), Color.White);


                    foreach (Tower turtle in turtleTowers)
                    {
                        turtle.PlaceTower(_spriteBatch, prevMouseState.X, prevMouseState.Y);
                    }

                    switch (inGameState)
                    {
                        case InGameState.Setup:
                            string timerString = String.Format("{0:0.00}", setupTimer);
                            _spriteBatch.DrawString(comicSans20, "Setup Time: " + timerString, new Vector2(500, 50), Color.White);

                            break;

                        // Starts the crab assault, drawing them and moving them towards the base
                        case InGameState.Assault:
                            if (basicCrabs.Count > 0)
                            {
                                foreach (Crab crab in basicCrabs)
                                {
                                    crab.Draw(_spriteBatch);
                                }

                            }

                            break;
                    }



                    _spriteBatch.DrawString(comicSans20, "Seashells: " + seashells, new Vector2(1000, 50), Color.White);


                    _spriteBatch.DrawString(comicSans20, "Tab -> Game Settings", new Vector2(600, 600), Color.SteelBlue);
                    _spriteBatch.DrawString(comicSans20, "Enter -> Game Over", new Vector2(600, 650), Color.SteelBlue);
                    break;

                case GameState.Settings_Game:

                    _spriteBatch.GraphicsDevice.Clear(Color.SeaGreen);
                    _spriteBatch.DrawString(comicSans20, "This is the Game Settings", new Vector2(300, 500), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Tab -> Game", new Vector2(300, 550), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Backspace -> Main Menu", new Vector2(300, 600), Color.White);

                    break;

                case GameState.GameOver:

                    _spriteBatch.GraphicsDevice.Clear(Color.Tomato);
                    _spriteBatch.DrawString(comicSans20, "GAME OVER, BITCHHHHHHHHHHH", new Vector2(300, 500), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Enter -> Main Menu", new Vector2(300, 550), Color.White);

                    break;

                case GameState.CutScene:

                    _spriteBatch.GraphicsDevice.Clear(Color.Black);
                    _spriteBatch.DrawString(comicSans20, "This is the opening cut scene! something cool is happening", new Vector2(300, 500), Color.White);
                    _spriteBatch.DrawString(comicSans20, "should be done in 5 seconds...", new Vector2(300, 600), Color.White);

                    break;
            }


            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}