using FallingWoman.Graphics;
using FallingWoman.UI;
using Microsoft.Xna.Framework;
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

        public OptionsScreen()
        {
            BackgroundColor = new Color(0, 0, 0, 255);
        }

        public override void OnShow()
        {
        }

        public override void Load(ContentManager content)
        {
            var spriteSheet = content.Load<Texture2D>("FallingSpriteSheet");
            _font = content.Load<SpriteFont>("AltText");

            var returnButtonSprite = new Sprite(spriteSheet, 160, 368, 112, 64);
            var returnButtonPosition = new Vector2(FallingWoman.ScreenWidth / 2.0f + 80, 50);
            var returnButton = new Button(returnButtonSprite, _font, returnButtonPosition);

            Buttons.Add(returnButton);

            returnButton.OnClick += OnReturnButtonClicked;
            {
                AddScreen?.Invoke(new MenuScreen());
            } 
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
