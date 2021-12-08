using FallingWoman.Helpers;
using FallingWoman.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace FallingWoman.Screens
{
    internal class CreditsScreen : BaseScreen
    {
        private SpriteFont _font;

        private const string Return = "menu";

        private SoundSystem _soundSystem;

        public CreditsScreen(SoundSystem soundSystem)
        {
            BackgroundColor = new Color(0, 0, 0, 255);
        }

        public override void Load(ContentManager content)
        {
            var spriteSheet = content.Load<Texture2D>("FallingSpriteSheet");
            _font = content.Load<SpriteFont>("AltText");

            var returnButton = UIHelpers.CreateButton(spriteSheet, new Rectangle(160, 368, 112, 64),
                new Vector2(FallingWoman.ScreenWidth / 2.0f + 80, 50), _font,
                () => { RequestScreenClose?.Invoke(); });

            Buttons.Add(returnButton);
        }

        public override void OnShow()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            spriteBatch.DrawString(_font, Return, new Vector2(FallingWoman.ScreenWidth / 2.0f + 40, 30), Color.White);

            spriteBatch.End();
        }

        protected override void OnUpdate(GameTime gameTime)
        {
        }
    }
}