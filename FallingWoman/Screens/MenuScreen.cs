using FallingWoman.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Screens
{
    public class MenuScreen : BaseScreen
    {
        private SpriteFont _playFont;
        private SpriteFont _altFont;

        private const string Play = "play";
        private const string Options = "options";
        private const string Credits = "credits";

        public MenuScreen() // Need to add sound
        {
            BackgroundColor = new Color(0, 0, 0, 255);
        }

        public override void OnShow()
        {
            // Menu song to play here
        }

        public override void Load(ContentManager content)
        {
            var spriteSheet = content.Load<Texture2D>("FallingSpriteSheet");
            _playFont = content.Load<SpriteFont>("PlayText");
            _altFont = content.Load<SpriteFont>("AltText");

            var playButton = UIHelpers.CreateButton(spriteSheet, new Rectangle(32, 32, 240, 144),
                new Vector2(FallingWoman.ScreenWidth / 2.0f, 125), _altFont,
                () => { AddScreen?.Invoke(new StartScreen()); });

            var optionsButton = UIHelpers.CreateButton(spriteSheet, new Rectangle(48, 192, 208, 96),
                new Vector2(FallingWoman.ScreenWidth / 2.0f, 300), _altFont,
                () => { AddScreen?.Invoke(new OptionsScreen()); });

            var creditsButton = UIHelpers.CreateButton(spriteSheet, new Rectangle(48, 192, 208, 96),
                new Vector2(FallingWoman.ScreenWidth / 2.0f, 425), _altFont,
                () => { AddScreen?.Invoke(new CreditsScreen()); });

            Buttons.Add(playButton);
            Buttons.Add(optionsButton);
            Buttons.Add(creditsButton);
        }

        public override void Initialize()
        {
        }

        protected override void OnUpdate(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            var (x, y) = _playFont.MeasureString(Play);
            spriteBatch.DrawString(_playFont, Play, new Vector2(FallingWoman.ScreenWidth / 2.0f - x / 2.1f, 70),
                Color.White);

            var (a, b) = _altFont.MeasureString(Options);
            spriteBatch.DrawString(_altFont, Options, new Vector2(FallingWoman.ScreenWidth / 2.0f - a / 2.0f, 280),
                Color.White);

            spriteBatch.DrawString(_altFont, Credits, new Vector2(FallingWoman.ScreenWidth / 2.0f - a / 2.0f, 400),
                Color.White);

            spriteBatch.End();
        }
    }
}