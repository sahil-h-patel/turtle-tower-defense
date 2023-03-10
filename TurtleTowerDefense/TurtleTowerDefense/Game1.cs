using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TurtleTowerDefense
{
    enum GameState { CutScene, MainMenu, Modes, Settings_Menu, Game, Settings_Game, GameOver }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D placeholder;
        private Texture2D bgTexture;

        //prototype sprites
        private Texture2D towerProtoTexture;
        private Texture2D crabProtoTexture;
        private SpriteFont comicSans20;

        private GameState currentState;
        private KeyboardState prevKbState;
        private double timer;

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
            timer = 5;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            placeholder = this.Content.Load<Texture2D>("placeholder");
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

            //managing game states FSM
            switch (currentState)
            {
                case GameState.MainMenu:

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
                    }

                    break;

                case GameState.Game:

                    //hitting tab goes to in-game settings
                    if (SingleKeyPress(Keys.Tab))
                    {
                        currentState = GameState.Settings_Game;
                    }

                    //hitting enter goes to game over
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

                    timer -= gameTime.ElapsedGameTime.TotalSeconds;

                    if(timer <= 0)
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;
            }

            prevKbState = kb;

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
                    _spriteBatch.Draw(placeholder, new Rectangle(100, 100, 70, 70), Color.White);

                    _spriteBatch.Draw(towerProtoTexture, new Rectangle(100, 200, 80, 80), Color.White);

                    _spriteBatch.Draw(crabProtoTexture, new Rectangle(1000, 200, 80, 80), Color.White);

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