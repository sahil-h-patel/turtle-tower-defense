using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TurtleTowerDefense
{
    enum GameState { CutScene, MainMenu, Modes, Settings_Menu, Game, Settings_Game, GameOver}

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D placeholder;
        private Texture2D bgTexture;
        private GameState currentState;

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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            placeholder = this.Content.Load <Texture2D>("placeholder");
            bgTexture = Content.Load<Texture2D>("bg");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(bgTexture, new Rectangle(0, 0, 1280, 720), Color.White);

            _spriteBatch.Draw(placeholder, new Rectangle(100, 100, 70, 70), Color.White);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}