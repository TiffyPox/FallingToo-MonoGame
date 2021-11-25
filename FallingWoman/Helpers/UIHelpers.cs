using System;
using FallingWoman.Graphics;
using FallingWoman.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Helpers
{
    public static class UIHelpers
    {
        public static Button CreateButton(Texture2D spriteSheet, Rectangle buttonSize, Vector2 buttonPosition, SpriteFont font, Action onClick)
        {
            var buttonSprite = new Sprite(spriteSheet, buttonSize.X, buttonSize.Y, buttonSize.Width, buttonSize.Height);
            return new Button(buttonSprite, font, buttonPosition)
            {
                OnClick = onClick
            };
        }
    }
}