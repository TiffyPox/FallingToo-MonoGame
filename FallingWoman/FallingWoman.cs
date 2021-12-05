using FallingWoman.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FallingWoman
{
    public class FallingWoman : Game
    {
        private const string GameTitle = "Falling Too";
        public static int ScreenWidth;
        public static int ScreenHeight;

        private readonly GraphicsDeviceManager _graphics;
         
        private readonly Stack<IScreen> _screens = new Stack<IScreen>();

        private SpriteBatch _spriteBatch;

        public const bool Debug = false;
        public static Texture2D Pixel;

        public FallingWoman()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Pixel = Content.Load<Texture2D>("pixel");
            ScreenWidth = _graphics.PreferredBackBufferWidth = 300;
            ScreenHeight = _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();

            Window.Title = GameTitle;

            AddScreen(new MenuScreen()); // need to add soundsystem
        }

        private void AddScreen(IScreen screen)
        {
            screen.Load(Content);
            screen.Initialize();
            screen.OnShow();
            screen.AddScreen += AddScreen;
            screen.RequestScreenClose += PopScreen;
            _screens.Push(screen);
        }

        private void PopScreen()
        {
            _screens.Pop();
            _screens.Peek()?.OnShow();
        }

        protected override void Update(GameTime gameTime)
        {
            _screens.Peek()?.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_screens.Peek().BackgroundColor);

            _screens.Peek()?.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
