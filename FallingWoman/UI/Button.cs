using FallingWoman.Entities;
using FallingWoman.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using FallingWoman.Helpers;

namespace FallingWoman.UI
{
    public class Button : IGameEntity
    {
        private bool _hovering;

        private readonly Sprite _sprite;
        
        private readonly SpriteFont _font;

        private readonly Vector2 _position;

        public Action OnClick { get; set; }

        public int DrawOrder => 0;

        public Button(Sprite sprite, SpriteFont font, Vector2 position)
        {
            _sprite = sprite;
            _font = font;
            _position = position;
        }

        public void OnCursorMove(Rectangle mouseBounds) => _hovering = GetBounds().Contains(mouseBounds);

        public void OnCursorClick(MouseButton button)
        {
            if (!_hovering)
            {
                return;
            }

            OnClick?.Invoke();
        }

        public void Update(GameTime gameTime)
        {
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            var color = _hovering ? Color.White * 0.3f : Color.White;

            _sprite.Draw(spriteBatch, _position, color);

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (FallingWoman.Debug)
            {
                DrawDebug(spriteBatch);
            }
        }

        private void DrawDebug(SpriteBatch spriteBatch)
        {
            var bounds = GetBounds();
            DrawHelpers.DrawRectangle(spriteBatch, bounds.X, bounds.Y, bounds.Width, bounds.Height, Color.Red, false);
        }

        private Rectangle GetBounds() => new Rectangle((int)(_position.X - _sprite.RenderWidth / 2.0f), (int)(_position.Y - _sprite.RenderHeight / 2.0f), _sprite.RenderWidth, _sprite.RenderHeight);
    }
}
