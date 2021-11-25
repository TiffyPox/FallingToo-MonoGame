using FallingWoman.Graphics;
using FallingWoman.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Screens
{
    public class GameScreen : BaseScreen
    {
        private bool _newGame;

        private SpriteFont _font;

        private const string Return = "menu";

        private Texture2D _spriteSheet;

        public GameScreen()
        {
            BackgroundColor = new Color(255, 255, 255, 0);
        }

        public override void Load(ContentManager content)
        {
            _font = content.Load<SpriteFont>("AltText");
            _spriteSheet = content.Load<Texture2D>("FallingSpriteSheet");

            var returnButtonSprite = new Sprite(_spriteSheet, 160, 368, 112, 64);
            var returnButtonPosition = new Vector2(FallingWoman.ScreenWidth / 2.0f + 80, 50);
            var returnButton = new Button(returnButtonSprite, _font, returnButtonPosition);

            Buttons.Add(returnButton);

            returnButton.OnClick += OnReturnButtonClicked;
            {
                AddScreen?.Invoke(new MenuScreen());
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            _newGame = true;
        }

        private void OnReturnButtonClicked()
        {
            RequestScreenClose?.Invoke();
        }

        public override void OnShow()
        {
        }

        protected override void OnUpdate(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            var (x, y) = _font.MeasureString(Return);
            spriteBatch.DrawString(_font, Return, new Vector2(FallingWoman.ScreenWidth / 2.0f + 40, 30), Color.White);

            spriteBatch.End();
        }
    }
}
