using FallingWoman.Graphics;
using FallingWoman.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Screens
{
    internal class StartScreen : BaseScreen
    {
        private Texture2D _spriteSheet;

        private SpriteFont _font;

        private const string Start = "start";

        private Animation _animation;

        public StartScreen()
        {
            BackgroundColor = new Color(255, 255, 255, 0);
        }

        public override void Load(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("IdleAnimation-Sheet");
            _font = content.Load<SpriteFont>("AltText");

            var startButton = UIHelpers.CreateButton(_spriteSheet, new Rectangle(163, 436, 125, 44),
                new Vector2(FallingWoman.ScreenWidth / 2.0f, FallingWoman.ScreenHeight / 2.0f + 20), _font,
                () => { AddScreen?.Invoke(new CutScene()); });

            Buttons.Add(startButton);
        }

        public override void Initialize()
        {
            base.Initialize();

            _animation = new Animation(new Vector2(300, 500), _spriteSheet.Width / 300);
        }

        public override void OnShow()
        {
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            spriteBatch.Draw(_spriteSheet, Vector2.Zero, _animation.GetFrame(), Color.White);
            spriteBatch.DrawString(_font, Start,
                new Vector2(FallingWoman.ScreenWidth / 2.0f - 51, FallingWoman.ScreenHeight / 2.0f), Color.White);

            spriteBatch.End();
        }
    }
}