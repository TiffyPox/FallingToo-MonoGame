using FallingWoman.Graphics;
using FallingWoman.Helpers;
using FallingWoman.Sound;
using FallingWoman.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Screens
{
    public class OptionsScreen : BaseScreen
    {
        private SpriteFont _font;

        private const string Music = "music";
        private const string Return = "menu";
        private const string On = "on";
        private const string Off = "off";

        private SoundSystem _soundSystem;
        private SoundEffect _song;
        
        private Texture2D _spriteSheet;

        public OptionsScreen(SoundSystem soundSystem)
        {
            _soundSystem = soundSystem;
            BackgroundColor = new Color(0, 0, 0, 255);
        }

        public override void OnShow()
        {
            _soundSystem.Play(_song);
        }

        public override void Load(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("FallingSpriteSheet");
            _font = content.Load<SpriteFont>("AltText");

            _song = content.Load<SoundEffect>("pianoMusic");
            
            var returnButton = UIHelpers.CreateButton(_spriteSheet, new Rectangle(160, 368, 112, 64),
                new Vector2(FallingWoman.ScreenWidth / 2.0f + 80, 50), _font,
                () => { AddScreen?.Invoke(new MenuScreen(_soundSystem)); });

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
