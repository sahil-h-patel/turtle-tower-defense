using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeUtils;
using System.Threading;

namespace TurtleTowerDefense
{
    enum GameState { CutScene, MainMenu, Modes, Settings_Menu, Game, Settings_Game, GameOver }
    enum BattleState { None, Setup, Assault }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D bgTexture;

        //prototype sprites
        private Texture2D towerProtoTexture;
        private Texture2D crabProtoTexture;
        private Texture2D SplashScreen;
        private Texture2D titleScreen;
        private Texture2D gameModeScreen;
        private SpriteFont comicSans20;

        //final sprites
        private Texture2D homeBaseTexture;
        private Texture2D cannonTowerTexture;
        private Texture2D catapultTowerTexture;
        private Texture2D fireTowerTexture;
        private Texture2D basicCrabTexture;
        private Texture2D fastCrabTexture;
        private Texture2D chungusCrabTexture;
        private Texture2D menuSettingsScreen;
        private Texture2D gameSettingsScreen;

        //button
        private Button classicModeButton;
        private Texture2D classicModeTexture;
        private Texture2D classicModeHoverTexture;
        private Button endlessModeButton;
        private Texture2D endlessModeTexture;
        private Texture2D endlessModeHoverTexture;
        private Button settingsButton;
        private Texture2D settingsButtonTexture;
        private Texture2D settingsButtonHoverTexture;
        private Button backButton;
        private Texture2D backButtonTexture;
        private Texture2D backButtonHoverTexture;
        private Button cannonButton;
        private Texture2D cannonButtonTexture;
        private Texture2D cannonButtonHoverTexture;
        private Button catapultButton;
        private Texture2D catapultButtonTexture;
        private Texture2D catapultButtonHoverTexture;
        private Button fireButton;
        private Texture2D fireButtonTexture;
        private Texture2D fireButtonHoverTexture;
        private Button gameSettingsButton;

        private GameState currentState;
        private BattleState inGameState;
        private KeyboardState prevKbState;
        private MouseState currentMouseState;
        private MouseState prevMouseState;
        private double cutsceneTimer;
        private double setupTimer;

        // Grid for building
        private Grid grid;

        // Cash for player
        private int seashells;

        // Contains all placed turtle towers
        private List<Tower> turtleTowers;
        // Contains all basicCrabs
        private bool crabListFilled;
        private List<Crab> basicCrabs;
        // Creates default towers for use of values
        private CannonTower defaultCannonTower;

        private int waveCounter;

        // Debug mode. Gives infinite money and makes homebase invincible.
        private bool debugMode;

        // Home Base 
        private int homeBaseHP;
        private Rectangle homeBaseRect;

        // Turtle Tower manager
        TurtleTowerInator towerManager;

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
            // Intializes all values right off the bat
            currentState = GameState.CutScene;
            inGameState = BattleState.None;
            waveCounter = 1;
            // Sets up timers for game
            cutsceneTimer = 5;
            setupTimer = 4;
            homeBaseHP = 100;
            homeBaseRect = new Rectangle(0, 240, 120, 240);

            //set up grid
            grid = new Grid(16, 28);

            debugMode = false;

            // Intialize TowerManager
            towerManager = new TurtleTowerInator();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //turtleTowers = new List<Tower>();
            basicCrabs = new List<Crab>();

            bgTexture = Content.Load<Texture2D>("bg");

            //prototype textures
            towerProtoTexture = Content.Load<Texture2D>("towerProto");
            crabProtoTexture = Content.Load<Texture2D>("crabProto");
            comicSans20 = Content.Load<SpriteFont>("comicSans20");
            SplashScreen = Content.Load<Texture2D>("MainMenuSplashScreen");
            titleScreen = Content.Load<Texture2D>("title screen");
            gameModeScreen = Content.Load<Texture2D>("game mode screen");

            //final sprite textures
            menuSettingsScreen = Content.Load<Texture2D>("main setting screen");
            gameSettingsScreen = Content.Load<Texture2D>("game setting screen");
            homeBaseTexture = Content.Load<Texture2D>("homebase sprite");
            cannonTowerTexture = Content.Load<Texture2D>("cannon tower sprite");
            basicCrabTexture = Content.Load<Texture2D>("basic crab sprite");

            //buttons
            classicModeTexture = Content.Load<Texture2D>("game mode classic");
            classicModeHoverTexture = Content.Load<Texture2D>("game mode classic hover");
            endlessModeTexture = Content.Load<Texture2D>("game mode endless");
            endlessModeHoverTexture = Content.Load<Texture2D>("game mode endless hover");
            settingsButtonTexture = Content.Load<Texture2D>("settings button");
            settingsButtonHoverTexture = Content.Load<Texture2D>("settings button hover");
            backButtonTexture = Content.Load<Texture2D>("back button");
            backButtonHoverTexture = Content.Load<Texture2D>("back button hover");
            cannonButtonTexture = Content.Load<Texture2D>("canon tower button");
            cannonButtonHoverTexture = Content.Load<Texture2D>("canon tower button hover");
            catapultButtonTexture = Content.Load<Texture2D>("catapult tower button");
            catapultButtonHoverTexture = Content.Load<Texture2D>("catapult tower button hover");
            fireButtonTexture = Content.Load<Texture2D>("fire tower button");
            fireButtonHoverTexture = Content.Load<Texture2D>("fire tower button hover");

            //set up buttons
            classicModeButton = new Button(470, 280, 394, 122, classicModeTexture, classicModeHoverTexture);
            endlessModeButton = new Button(470, 450, 393, 123, endlessModeTexture, endlessModeHoverTexture);
            settingsButton = new Button(1140, 30, 67, 67, settingsButtonTexture, settingsButtonHoverTexture);
            backButton = new Button(960, 120, 57, 58, backButtonTexture, backButtonHoverTexture);
            cannonButton = new Button(1140, 450, 115, 114, cannonButtonTexture, cannonButtonHoverTexture);
            catapultButton = new Button(1140, 300, 115, 114, catapultButtonTexture, catapultButtonHoverTexture);
            fireButton = new Button(1140, 150, 115, 114, fireButtonTexture, fireButtonHoverTexture);
            gameSettingsButton = new Button(1160, 620, 67, 67, settingsButtonTexture, settingsButtonHoverTexture);

            defaultCannonTower = new CannonTower(cannonTowerTexture, -50, -50);
            // Loads up content with TurtleTowerInator 
            towerManager.LoadContent(Content);


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
            currentMouseState = Mouse.GetState();

            //managing game states FSM
            switch (currentState)
            {
                case GameState.MainMenu:
                    // Resets towers and wave counter if values were modified
                    towerManager.Reset();
                    waveCounter = 1;
                    setupTimer = 4;

                    settingsButton.Update();

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
                    // Turns on debug mode
                    if (SingleKeyPress(Keys.D))
                    {
                        debugMode = true;
                    }

                    break;

                case GameState.Settings_Menu:
                    backButton.Update();

                    //hitting tab goes back to the main menu
                    if (SingleKeyPress(Keys.Tab))
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;

                case GameState.Modes:

                    classicModeButton.Update();
                    endlessModeButton.Update();

                    //hitting backspace goes back to the main menu
                    if (SingleKeyPress(Keys.Back))
                    {
                        currentState = GameState.MainMenu;
                    }
                    //hitting enter starts game
                    if (SingleKeyPress(Keys.Enter))
                    {
                        currentState = GameState.Game;
                        inGameState = BattleState.Setup;
                        seashells = 100;
                        if (debugMode == true)
                        {
                            seashells = 999999999;
                        }

                    }

                    break;

                // Begin the game! The game state also has a few game states as well, 
                case GameState.Game:

                    gameSettingsButton.Update();

                    switch (inGameState)
                    {
                        // Allows the player time to place and upgrade towers
                        case BattleState.Setup:
                            crabListFilled = false;
                            basicCrabs.Clear();
                            cannonButton.Update();
                            catapultButton.Update();
                            fireButton.Update();

                            // If you run out of time setting up, change into assault mode, beginning the crab attack
                            setupTimer -= gameTime.ElapsedGameTime.TotalSeconds;

                            if (setupTimer <= 0)
                            {
                                inGameState = BattleState.Assault;
                            }

                            // Places a tower, if the player has enough cash
                            towerManager.PlaceTower(grid, ref seashells, currentMouseState, prevMouseState);

                            break;



                        // Begins the crab assault on the turtle base
                        case BattleState.Assault:
                            // This will add the appropriate amount of crabs to the list to be spawned.
                            if (basicCrabs.Count < 1 + waveCounter && !crabListFilled)
                            {
                                for (int i = 0; i < 1 + waveCounter; i++)
                                {
                                    basicCrabs.Add(new BasicCrab(basicCrabTexture, _graphics.PreferredBackBufferWidth + 10 + (i * 80), _graphics.PreferredBackBufferHeight / 2));
                                }
                                crabListFilled = true;
                            }
                            if (basicCrabs.Count == 0)
                            {
                                waveCounter++;
                                setupTimer = 15;
                                inGameState = BattleState.Setup;
                            }

                            // Checks for Crab Targets
                            towerManager.AttackEnemies(basicCrabs, gameTime);

                            // Moves crabs, along with a timer spacing them out from being spawned
                            for (int i = 0; i < basicCrabs.Count; i++)   
                            {
                                basicCrabs[i].X -= 2;
                                if (basicCrabs[i].Health <= 0)
                                {
                                    seashells += 15;
                                    basicCrabs.Remove(basicCrabs[i]);
                                }
                            }
                            break;

                    }

                    //hitting tab goes to in-game settings, enter goes to GameOver, or if home base hp is <= 0
                    if (SingleKeyPress(Keys.Tab))
                    {
                        currentState = GameState.Settings_Game;
                    }
                    if (SingleKeyPress(Keys.Enter) || homeBaseHP <= 0)
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
                    if (SingleKeyPress(Keys.Enter))
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;
            }

            prevKbState = kb;
            prevMouseState = currentMouseState;

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

                    _spriteBatch.GraphicsDevice.Clear(Color.White);
                    _spriteBatch.Draw(titleScreen, new Rectangle(0, 0, 1280, 720), Color.White);
                    _spriteBatch.DrawString(comicSans20, "This is the Main Menu!", new Vector2(50, 500), Color.Black);
                    _spriteBatch.DrawString(comicSans20, "Tab -> Menu Settings", new Vector2(50, 550), Color.Black);
                    _spriteBatch.DrawString(comicSans20, "Enter -> Game Modes", new Vector2(50, 600), Color.Black);
                    settingsButton.Draw(_spriteBatch);
                    break;

                case GameState.Settings_Menu:

                    _spriteBatch.GraphicsDevice.Clear(Color.MediumBlue);
                    _spriteBatch.DrawString(comicSans20, "This is the Menu Settings", new Vector2(300, 500), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Tab -> Main Menu", new Vector2(300, 550), Color.White);
                    backButton.Draw(_spriteBatch);

                    break;

                case GameState.Modes:

                    _spriteBatch.GraphicsDevice.Clear(Color.PeachPuff);
                    _spriteBatch.Draw(gameModeScreen, new Rectangle(0, 0, 1280, 720), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Enter -> Game", new Vector2(50, 550), Color.Chocolate);
                    _spriteBatch.DrawString(comicSans20, "Backspace -> Main Menu", new Vector2(50, 600), Color.CadetBlue);
                    classicModeButton.Draw(_spriteBatch);
                    endlessModeButton.Draw(_spriteBatch);

                    break;

                case GameState.Game:
                    //background image
                    _spriteBatch.Draw(bgTexture, new Rectangle(0, 0, 1280, 720), Color.White);

                    gameSettingsButton.Draw(_spriteBatch);

                    //tower sprite place holder
                    _spriteBatch.Draw(homeBaseTexture, homeBaseRect, Color.White);

                    // If in debug mode, draw circle outlines around the turtle towers
                    if (debugMode)
                    {
                        _spriteBatch.End();
                        ShapeBatch.Begin(GraphicsDevice);
                        foreach (Tower turtle in turtleTowers)
                        {
                            ShapeBatch.CircleOutline(turtle.Center, (float)turtle.BaseDetectionRadius, Color.Black);
                        }
                        ShapeBatch.End();
                        _spriteBatch.Begin();
                    }


                    towerManager.DrawTowers(_spriteBatch);

                    switch (inGameState)
                    {
                        // Specifics during setup phase
                        case BattleState.Setup:
                            string timerString = String.Format("{0:0}", setupTimer);
                            cannonButton.Draw(_spriteBatch);
                            catapultButton.Draw(_spriteBatch);
                            fireButton.Draw(_spriteBatch);
                            _spriteBatch.DrawString(comicSans20, "Setup Time: " + timerString, new Vector2(500, 25), Color.White);

                            _spriteBatch.End();

                            //draw grid
                            ShapeBatch.Begin(GraphicsDevice);
                            grid.DrawGrid(prevMouseState);
                            ShapeBatch.End();

                            _spriteBatch.Begin();

                            break;

                        // Starts the crab assault, drawing them and moving them towards the base
                        case BattleState.Assault:

                            for (int i = 0; i < basicCrabs.Count; i++)
                            {
                                basicCrabs[i].Draw(_spriteBatch);
                                // If in debug mode, print crab HP
                                if (debugMode)
                                {
                                    _spriteBatch.DrawString(comicSans20, $"{basicCrabs[i].Health}", new Vector2(basicCrabs[i].X + basicCrabs[i].Width / 2, basicCrabs[i].Y + basicCrabs[i].Height / 2), Color.White);
                                }
                                if (basicCrabs[i].Hitbox.Intersects(homeBaseRect))
                                {
                                    homeBaseHP -= 10;
                                    basicCrabs.Remove(basicCrabs[i]);
                                }
                            }


                            break;
                    }


                    _spriteBatch.DrawString(comicSans20, "Home Base HP: " + homeBaseHP, new Vector2(50, 80), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Wave " + waveCounter, new Vector2(120, 15), Color.White);
                    _spriteBatch.DrawString(comicSans20, $"{seashells}", new Vector2(1090, 25), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Tab -> Game Settings", new Vector2(600, 600), Color.SteelBlue);
                    _spriteBatch.DrawString(comicSans20, "Enter -> Game Over", new Vector2(600, 650), Color.SteelBlue);
                    break;

                case GameState.Settings_Game:

                    _spriteBatch.GraphicsDevice.Clear(Color.SeaGreen);
                    _spriteBatch.DrawString(comicSans20, "This is the Game Settings", new Vector2(300, 500), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Tab -> Game", new Vector2(300, 550), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Backspace -> Main Menu", new Vector2(300, 600), Color.White);


                    backButton.Draw(_spriteBatch);

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