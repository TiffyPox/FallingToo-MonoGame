using FallingWoman.Helpers;
using FallingWoman.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Screens
{
    public class OptionsScreen : BaseScreen
    {
        // User can mute the music and sounds in this screen
        
        private SpriteFont _font;

        private const string Music = "music";
        private const string Return = "menu";
        private const string On = "on";
        private const string Off = "off";

        private SoundSystem _soundSystem;
        
        private Texture2D _spriteSheet;

        public OptionsScreen(SoundSystem soundSystem)
        {
            BackgroundColor = new Color(0, 0, 0, 255);
        }

        public override void OnShow()
        {
        }

        public override void Load(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("FallingSpriteSheet");
            _font = content.Load<SpriteFont>("AltText");
            
            var returnButton = UIHelpers.CreateButton(_spriteSheet, new Rectangle(160, 368, 112, 64),
                new Vector2(FallingWoman.ScreenWidth / 2.0f + 80, 50), _font,
                () => { RequestScreenClose?.Invoke(); });

            Buttons.Add(returnButton);
        }

        private void OnReturnButtonClicked()
        {
            RequestScreenClose?.Invoke();
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
