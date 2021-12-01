using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Screens
{
    public class GameScreen : BaseScreen
    {
        private bool _newGame;

        private Texture2D _spriteSheet;

        public GameScreen()
        {
            BackgroundColor = new Color(255, 255, 255, 0);
        }

        public override void Load(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("FallingSpriteSheet");
        }

        public override void Initialize()
        {
            base.Initialize();

            _newGame = true;
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

            spriteBatch.End();
        }
    }
}
