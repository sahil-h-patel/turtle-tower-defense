using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeUtils;
using System.Threading;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace TurtleTowerDefense
{
    enum TowerType { None, Cannon, Catapult, Fire };
    enum TutorialPage { Page1, Page2 };
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D bgTexture;
        //private Microsoft.Xna.Framework.Media.

        //prototype sprites
        private Texture2D SplashScreen;
        private Texture2D titleScreen;
        private Texture2D gameModeScreen;
        private SpriteFont comicSans20;
        //private SpriteFont tsuki20;
        //private SpriteFont tsukiBig;
        //private SpriteFont tsukiBigCash;

        //final sprites
        private Texture2D homeBaseTexture;
        private Texture2D cannonTowerTexture;
        private Texture2D gameOverScreen;
        private Texture2D menuSettingsScreen;
        private Texture2D gameSettingsScreen;
        private Texture2D resetWaveTexture;
        private Texture2D turnPathTexture;
        private Texture2D straightPathTexture;

        #region Buttons
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
        private Button backButtonMenu;
        private Button backButtonGame;
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
        private Button skipButton;
        private Texture2D skipTexture;
        private Texture2D skipHoverTexture;
        private Button backButtonMode;
        private Button quitToMenuButton;
        private Texture2D quitTexture;
        private Texture2D quitHoverTexture;
        private Texture2D cannonButtonSelectedTexture;
        private Texture2D catapultButtonSelectedTexture;
        private Texture2D fireButtonSelectedTexture;
        private Texture2D tutorial1Texture;
        private Texture2D tutorial2Texture;
        private Texture2D tutorialNextTexture;
        private Texture2D tutorialNextHoverTexture;
        private Button tutorialNextButton;
        private Texture2D tutorialOkTexture;
        private Texture2D tutorialOkHoverTexture;
        private Button tutorialOkButton; 
        #endregion

        private GameState currentState;
        private BattleState inGameState;
        private TowerType currentTower;
        private TutorialPage currentTutorialPage;
        private KeyboardState prevKbState;
        private MouseState currentMouseState;
        private MouseState prevMouseState;
        private double cutsceneTimer;
        private double setupTimer;

        // Grid for building
        private Grid grid;

        // Cash for player
        private int seashells;
        private int spentShells;

        private int waveCounter;
        private ResetWave wave;
        private Rectangle resetWaveRect;
        // Debug mode. Gives infinite money and makes homebase invincible.
        private bool debugMode;

        //determines whether to show tutorial to player or not
        private bool firstPlay;

        // Home Base 
        private float homeBaseTimer;
        private int prevHomeBaseHP;
        private int homeBaseHP;
        private Rectangle homeBaseRect;

        // Managers
        TurtleTowerInator towerManager;
        CrabInator crabManager;

        Level currentLevel;

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
            currentState = GameState.MainMenu;
            inGameState = BattleState.None;
            currentTower = TowerType.None;
            waveCounter = 1;
            // Sets up timers for game
            cutsceneTimer = 5;
            setupTimer = 4;
            homeBaseHP = 100;
            homeBaseRect = new Rectangle(0, 240, 120, 240);
            resetWaveRect = new Rectangle(1280, 0, 2000, 720);

            //set up grid
            grid = new Grid(16, 31);

            debugMode = false;
            firstPlay = true;

            // Intialize managers
            towerManager = new TurtleTowerInator();
            crabManager = new CrabInator();

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bgTexture = Content.Load<Texture2D>("game bg");

            //prototype textures
            comicSans20 = Content.Load<SpriteFont>("comicSans20");
            //tsuki20 = Content.Load<SpriteFont>("TsukiFont");
            //tsukiBig = Content.Load<SpriteFont>("TsukiFontBig");
            //tsukiBigCash = Content.Load<SpriteFont>("TsukiFontCash");
            SplashScreen = Content.Load<Texture2D>("MainMenuSplashScreen");
            titleScreen = Content.Load<Texture2D>("title screen");
            gameModeScreen = Content.Load<Texture2D>("game mode screen");

            //final sprite textures
            menuSettingsScreen = Content.Load<Texture2D>("main setting screen");
            gameSettingsScreen = Content.Load<Texture2D>("game setting screen");
            gameOverScreen = Content.Load<Texture2D>("game over");
            tutorial1Texture = Content.Load<Texture2D>("tutorial screen 1");
            tutorial2Texture = Content.Load<Texture2D>("tutorial screen 2");
            homeBaseTexture = Content.Load<Texture2D>("homebase sprite");
            cannonTowerTexture = Content.Load<Texture2D>("cannon tower sprite");
            resetWaveTexture = Content.Load<Texture2D>("reset wave");
            turnPathTexture = Content.Load<Texture2D>("turn path");
            straightPathTexture = Content.Load<Texture2D>("straight path");
            //buttons
            classicModeTexture = Content.Load<Texture2D>("game mode classic");
            classicModeHoverTexture = Content.Load<Texture2D>("game mode classic hover");
            endlessModeTexture = Content.Load<Texture2D>("game mode endless");
            endlessModeHoverTexture = Content.Load<Texture2D>("game mode endless hover");
            settingsButtonTexture = Content.Load<Texture2D>("settings button");
            settingsButtonHoverTexture = Content.Load<Texture2D>("settings button hover");
            backButtonTexture = Content.Load<Texture2D>("back button");
            backButtonHoverTexture = Content.Load<Texture2D>("back button hover");
            cannonButtonTexture = Content.Load<Texture2D>("cannon tower button");
            cannonButtonHoverTexture = Content.Load<Texture2D>("cannon tower button hover");
            catapultButtonTexture = Content.Load<Texture2D>("catapult tower button");
            catapultButtonHoverTexture = Content.Load<Texture2D>("catapult tower button hover");
            fireButtonTexture = Content.Load<Texture2D>("fire tower button");
            fireButtonHoverTexture = Content.Load<Texture2D>("fire tower button hover");
            skipTexture = Content.Load<Texture2D>("skip button");
            skipHoverTexture = Content.Load<Texture2D>("skip button hover");
            quitTexture = Content.Load<Texture2D>("quit button");
            quitHoverTexture = Content.Load<Texture2D>("quit button hover");
            cannonButtonSelectedTexture = Content.Load<Texture2D>("cannon button selected");
            catapultButtonSelectedTexture = Content.Load<Texture2D>("catapult button selected");
            fireButtonSelectedTexture = Content.Load<Texture2D>("fire button selected");
            tutorialNextTexture = Content.Load<Texture2D>("tutorial next");
            tutorialNextHoverTexture = Content.Load<Texture2D>("tutorial next hover");
            tutorialOkTexture = Content.Load<Texture2D>("tutorial ok");
            tutorialOkHoverTexture = Content.Load<Texture2D>("tutorial ok hover");


            //set up buttons
            classicModeButton = new Button(470, 280, 394, 122, classicModeTexture, classicModeHoverTexture);
            endlessModeButton = new Button(470, 450, 393, 123, endlessModeTexture, endlessModeHoverTexture);
            settingsButton = new Button(1160, 30, 67, 67, settingsButtonTexture, settingsButtonHoverTexture);
            backButtonMenu = new Button(960, 120, 57, 58, backButtonTexture, backButtonHoverTexture);
            backButtonGame = new Button(960, 120, 57, 58, backButtonTexture, backButtonHoverTexture);
            cannonButton = new Button(1140, 460, 115, 114, cannonButtonTexture, cannonButtonHoverTexture);
            catapultButton = new Button(1140, 310, 115, 114, catapultButtonTexture, catapultButtonHoverTexture);
            fireButton = new Button(1140, 160, 115, 114, fireButtonTexture, fireButtonHoverTexture);
            gameSettingsButton = new Button(1160, 620, 67, 67, settingsButtonTexture, settingsButtonHoverTexture);
            skipButton = new Button(1165, 65, 67, 67, skipTexture, skipHoverTexture);
            backButtonMode = new Button(960, 120, 57, 58, backButtonTexture, backButtonHoverTexture);
            quitToMenuButton = new Button(420, 430, 479, 112, quitTexture, quitHoverTexture);
            tutorialOkButton = new Button(500, 480, 330, 106, tutorialOkTexture, tutorialOkHoverTexture);
            tutorialNextButton = new Button(920, 520, 79, 69, tutorialNextTexture, tutorialNextHoverTexture);

            //set up button events
            classicModeButton.Click += GameStart_Clicked;
            endlessModeButton.Click += GameStart_Clicked;
            settingsButton.Click += MenuSettings_Clicked;
            backButtonMenu.Click += BackMenu_Clicked;
            backButtonMode.Click += BackMenu_Clicked;
            backButtonGame.Click += BackGame_Clicked;
            gameSettingsButton.Click += GameSettings_Clicked;
            skipButton.Click += Skip_Clicked;
            quitToMenuButton.Click += BackMenu_Clicked;
            cannonButton.Click += Select_Cannon;
            catapultButton.Click += Select_Catapult;
            fireButton.Click += Select_Fire;
            tutorialNextButton.Click += TutorialNext_Clicked;
            tutorialOkButton.Click += TutorialOk_Clicked;

            // Loads up content for managers
            towerManager.LoadContent(Content);
            crabManager.LoadContent(Content);

            // Creates a new Level object
            currentLevel = new Level(straightPathTexture, turnPathTexture);
            // Initializing resetWave
            wave = new ResetWave(resetWaveTexture, resetWaveRect, towerManager.Towers, 2);

        }

        /// <summary>
        /// starts the game
        /// </summary>
        private void StartGame()
        {
            currentState = GameState.Game;
            inGameState = BattleState.Setup;
            seashells = 100;
            if (debugMode == true)
            {
                seashells = 999999999;
            }
        }

        #region MyRegion
        // Whole ton of button events
        private void GameStart_Clicked(object sender, System.EventArgs e)
        {
            if (firstPlay)
            {
                currentState = GameState.Tutorial;
                currentTutorialPage = TutorialPage.Page1;
            }
            else

            {
                StartGame();
                wave.FillLevelList("../../../Levels/Map1/");
                wave.ChooseLevel(ref currentLevel, grid);
            }

        }

        private void TutorialNext_Clicked(object sender, System.EventArgs e)
        {
            currentTutorialPage = TutorialPage.Page2;
        }

        private void TutorialOk_Clicked(object sender, System.EventArgs e)
        {
            firstPlay = false;
            StartGame();
            wave.FillLevelList("../../../Levels/Map1/");
            wave.ChooseLevel(ref currentLevel, grid);
        }

        private void MenuSettings_Clicked(object sender, System.EventArgs e)
        {
            currentState = GameState.Settings_Menu;
        }

        private void BackMenu_Clicked(object sender, System.EventArgs e)
        {
            currentState = GameState.MainMenu;
        }

        private void BackGame_Clicked(object sender, System.EventArgs e)
        {
            currentState = GameState.Game;
        }

        private void GameSettings_Clicked(object sender, System.EventArgs e)
        {
            currentState = GameState.Settings_Game;
        }

        private void Skip_Clicked(object sender, System.EventArgs e)
        {
            inGameState = BattleState.Assault;
        }

        private void Select_Cannon(object sender, System.EventArgs e)
        {
            currentTower = TowerType.Cannon;
        }

        private void Select_Catapult(object sender, System.EventArgs e)
        {
            currentTower = TowerType.Catapult;
        }

        private void Select_Fire(object sender, System.EventArgs e)
        {
            currentTower = TowerType.Fire;
        } 
        #endregion

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
                    grid.Reset();
                    crabManager.Reset();
                    wave.ResetAll();
                    homeBaseHP = 100;
                    waveCounter = 1;
                    setupTimer = 10;
                    spentShells = 0;

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
                    backButtonMenu.Update();

                    //hitting tab goes back to the main menu
                    if (SingleKeyPress(Keys.Tab))
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;

                case GameState.Modes:

                    classicModeButton.Update();
                    endlessModeButton.Update();
                    backButtonMode.Update();

                    //hitting backspace goes back to the main menu
                    if (SingleKeyPress(Keys.Back))
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;

                // Begin the game! The game state also has a few game states as well, 
                case GameState.Game:
                    gameSettingsButton.Update();

                    if (homeBaseHP <= 0)
                    {
                        currentState = GameState.GameOver;
                    }

                    switch (inGameState)
                    {
                        // Allows the player time to place and upgrade towers
                        case BattleState.Setup:
                            // Wave shenanigans
                            if (wave.WaveTimer <= 0)
                            {
                                wave.Active = true;
                                inGameState = BattleState.Wave;
                            }

                            towerManager.RemoveTargets();

                            // For buttons' sake
                            cannonButton.Update();
                            catapultButton.Update();
                            fireButton.Update();
                            skipButton.Update();

                            // If you run out of time setting up, change into assault mode, beginning the crab attack

                            setupTimer -= gameTime.ElapsedGameTime.TotalSeconds;

                            if (setupTimer <= 0)
                            {
                                inGameState = BattleState.Assault;
                            }

                            // Places a tower, if the player has enough cash and one is selected

                            if (currentTower != TowerType.None)
                            {
                                towerManager.PlaceTower(grid, ref seashells, ref spentShells, currentMouseState, prevMouseState, ref currentTower);
                            }
                            break;



                        // Begins the crab assault on the turtle base
                        case BattleState.Assault:

                            currentTower = TowerType.None;
                            // This will add the appropriate amount of crabs to the list to be spawned.
                            crabManager.CrabSpawning(waveCounter, grid);
                            crabManager.CrabMovement(grid, ref homeBaseHP, ref seashells);

                            if (crabManager.Crabs.Count == 0)
                            {
                                waveCounter++;
                                setupTimer = 15;
                                inGameState = BattleState.Setup;
                                wave.WaveTimer--;
                            }

                            // Checks for Crab Targets
                            towerManager.AttackEnemies(crabManager.Crabs, gameTime);
                            break;

                        case BattleState.Wave:
                            grid.Reset();
                            wave.Update(_graphics, currentLevel, towerManager.Towers, ref inGameState, grid);
                            // Refunds half of what was spent
                            seashells += spentShells/2;
                            spentShells = 0;
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

                //introduction to the game if it is the first time that the user is playing
                case GameState.Tutorial:
                    switch (currentTutorialPage)
                    {
                        case TutorialPage.Page1:
                            tutorialNextButton.Update();
                            break;

                        case TutorialPage.Page2:
                            tutorialOkButton.Update();
                            break;
                    }
                    break;


                case GameState.Settings_Game:

                    backButtonGame.Update();
                    quitToMenuButton.Update();

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
                    settingsButton.Draw(_spriteBatch);
                    break;

                case GameState.Settings_Menu:

                    _spriteBatch.GraphicsDevice.Clear(Color.MediumBlue);
                    _spriteBatch.Draw(menuSettingsScreen, new Rectangle(0, 0, 1280, 720), Color.White);
                    backButtonMenu.Draw(_spriteBatch);

                    break;

                case GameState.Modes:

                    _spriteBatch.GraphicsDevice.Clear(Color.PeachPuff);
                    _spriteBatch.Draw(gameModeScreen, new Rectangle(0, 0, 1280, 720), Color.White);
                    classicModeButton.Draw(_spriteBatch);
                    endlessModeButton.Draw(_spriteBatch);
                    backButtonMode.Draw(_spriteBatch);

                    break;

                case GameState.Tutorial:
                    _spriteBatch.Draw(bgTexture, new Rectangle(0, 0, 1280, 720), Color.White);

                    switch (currentTutorialPage)
                    {
                        case TutorialPage.Page1:
                            _spriteBatch.Draw(tutorial1Texture, new Rectangle(0, 0, 1280, 720), Color.White);
                            _spriteBatch.DrawString(comicSans20, "Protect your turtle babies from \nthe incoming crab invasion!", new Vector2(450, 470), Color.White);
                            tutorialNextButton.Draw(_spriteBatch);
                            break;

                        case TutorialPage.Page2:
                            _spriteBatch.Draw(tutorial2Texture, new Rectangle(0, 0, 1280, 720), Color.White);
                            _spriteBatch.DrawString(comicSans20, "Use these buttons to place down turtle \ntowers and defend the home base!", new Vector2(380, 350), Color.White);
                            tutorialOkButton.Draw(_spriteBatch);
                            break;
                    }
                    break;

                case GameState.Game:
                    //background image
                    _spriteBatch.Draw(bgTexture, new Rectangle(0, 0, 1280, 720), Color.White);
                    gameSettingsButton.Draw(_spriteBatch);

                    _spriteBatch.DrawString(comicSans20, "Home Base HP: " + homeBaseHP, new Vector2(48, 80), Color.White);
                    _spriteBatch.DrawString(comicSans20, "Wave " + waveCounter, new Vector2(120, 15), Color.White);
                    _spriteBatch.DrawString(comicSans20, $"{seashells}", new Vector2(1090, 10), Color.White);

                    grid.DrawPath(_spriteBatch);
                    towerManager.DrawTowers(_spriteBatch, GraphicsDevice, gameTime, debugMode);
                    _spriteBatch.Draw(homeBaseTexture, new Rectangle(homeBaseRect.X + 120 / 2, homeBaseRect.Y + 120 / 2, homeBaseRect.Width, homeBaseRect.Height), new Rectangle(0, 0, 120, homeBaseTexture.Height), Color.White, 0f, new Vector2(120 / 2, 120 / 2), SpriteEffects.None, 0f); 
                    switch (inGameState)
                    {

                        // Specifics during setup phase
                        case BattleState.Setup:

                            string timerString = String.Format("{0:0}", setupTimer);
                            cannonButton.Draw(_spriteBatch);
                            catapultButton.Draw(_spriteBatch);
                            fireButton.Draw(_spriteBatch);
                            skipButton.Draw(_spriteBatch);
                            switch (currentTower)
                            {
                                case TowerType.Cannon:
                                    _spriteBatch.Draw(cannonButtonSelectedTexture, new Rectangle(1140, 460, 115, 114), Color.White);

                                    break;

                                case TowerType.Catapult:
                                    _spriteBatch.Draw(catapultButtonSelectedTexture, new Rectangle(1140, 310, 115, 114), Color.White);
                                    break;

                                case TowerType.Fire:
                                    _spriteBatch.Draw(fireButtonSelectedTexture, new Rectangle(1140, 160, 115, 114), Color.White);
                                    break;
                            }

                            _spriteBatch.DrawString(comicSans20, "Setup Time: " + timerString, new Vector2(500, 25), Color.White);


                            //draw grid
                            if (currentTower != TowerType.None)
                            {
                                _spriteBatch.End();

                                ShapeBatch.Begin(GraphicsDevice);
                                grid.DrawGrid(prevMouseState, currentTower);
                                ShapeBatch.End();

                                _spriteBatch.Begin();
                            }

                            // Depending on the type of tower selected, a transparent sillhoute will be drawn
                            switch (currentTower)
                            {
                                case TowerType.Cannon:

                                    break;

                                case TowerType.Catapult:

                                    break;

                                case TowerType.Fire:

                                    break;
                            }
                            break;

                        // Starts the crab assault, drawing them and moving them towards the base
                        case BattleState.Assault:
                            crabManager.Draw(_spriteBatch, currentMouseState, GraphicsDevice, debugMode);
                            break;

                        case BattleState.Wave:
                            wave.Draw(_spriteBatch);
                            break;
                    }


                    if (debugMode)
                    {
                        _spriteBatch.DrawString(comicSans20, "Enter -> Game Over", new Vector2(50, 650), Color.White);
                    }
                    break;

                case GameState.Settings_Game:

                    _spriteBatch.GraphicsDevice.Clear(Color.SeaGreen);
                    _spriteBatch.Draw(bgTexture, new Rectangle(0, 0, 1280, 720), Color.White);
                    _spriteBatch.Draw(gameSettingsScreen, new Rectangle(0, 0, 1280, 720), Color.White);

                    quitToMenuButton.Draw(_spriteBatch);
                    backButtonGame.Draw(_spriteBatch);

                    break;

                case GameState.GameOver:

                    _spriteBatch.GraphicsDevice.Clear(Color.Tomato);
                    _spriteBatch.Draw(gameOverScreen, new Rectangle(0, 0, 1280, 720), Color.White);

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