using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace FallingWoman.Screens
{
    public class GameScreen : BaseScreen
    {
        private bool _newGame;

        private Texture2D _background;

        private float _backgroundY;

        private float _duplicateY;

        private Texture2D _spriteSheet;

        public GameScreen()
        {
            BackgroundColor = new Color(255, 255, 255, 0);
        }

        public override void Load(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("FallingSpriteSheet");
            _background = content.Load<Texture2D>("GameBackground");
        }

        public override void Initialize()
        {
            base.Initialize();

            _duplicateY = _background.Height;

            _newGame = true;
        }

        public override void OnShow()
        {
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            _backgroundY--;
            _backgroundY -= 5;

            _duplicateY--;
            _duplicateY -= 5;

            if (_duplicateY <= 0)
            {
                _duplicateY = _background.Height;
                _backgroundY = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            
            spriteBatch.Draw(_background, new Vector2(0,_backgroundY), Color.White);
            
            spriteBatch.Draw(_background, new Vector2(0,_duplicateY), Color.White);

            spriteBatch.End();
        }
    }
}
