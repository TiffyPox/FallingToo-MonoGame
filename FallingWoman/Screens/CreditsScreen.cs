using FallingWoman.Helpers;
using FallingWoman.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Screens
{
    internal class CreditsScreen : BaseScreen
    {
        // A screen to credit the musicians
        // Cutscene music is 'Emotional Piano' by @tictac9
        // Credits is 'Piano Major7's' by @tictac9
        // Menu music is 'Soundscape' by @tictac9
        // Game music is 'Voyager' by @tictac9
        // Pop sound effect is by @InspectorJ
        // Explosion sound effect is by @qubodup
        
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