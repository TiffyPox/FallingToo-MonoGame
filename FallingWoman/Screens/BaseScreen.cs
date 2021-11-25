using System;
using System.Collections.Generic;
using FallingWoman.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FallingWoman.Screens
{
    public abstract class BaseScreen : IScreen
    {
        protected readonly List<Button> Buttons = new List<Button>();
        private MouseState _lastMouseState;
        private MouseState _currentMouseState;

        public Color BackgroundColor { get; protected set; }

        public Action RequestScreenClose { get; set; }
        public Action<IScreen> AddScreen { get; set; }

        public abstract void OnShow();

        public abstract void Load(ContentManager content);

        public virtual void Initialize()
        {
        }

        public void Update(GameTime gameTime)
        {
            _currentMouseState = Mouse.GetState();
            var mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);

            foreach (var button in Buttons)
            {
                // Moving
                if (_currentMouseState.X != _lastMouseState.X || _currentMouseState.Y != _lastMouseState.Y)
                {
                    button.OnCursorMove(mouseRectangle);
                }

                // Clicking
                if (_lastMouseState.LeftButton == ButtonState.Pressed && _currentMouseState.LeftButton == ButtonState.Released)
                {
                    button.OnCursorClick(MouseButton.Left);
                }

                button.Update(gameTime);
            }

            OnUpdate(gameTime);

            _lastMouseState = _currentMouseState;
        }

        protected abstract void OnUpdate(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach (var button in Buttons)
            {
                button.Draw(spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
