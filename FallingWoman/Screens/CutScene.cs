using FallingWoman.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Screens
{
    public class CutScene : BaseScreen
    {
        private Texture2D _spriteSheet;

        private Animation _animation;

        public CutScene()
        {
            BackgroundColor = new Color(255, 255, 255, 0);
        }

        public override void Load(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("FallingAnimation-Sheet");
        }

        public override void Initialize()
        {
            base.Initialize();

            _animation = new Animation(new Vector2(300, 500), _spriteSheet.Width / 300, false)
            {
                OnFinish = () =>
                {
                    AddScreen?.Invoke(new GameScreen());
                }
            };
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
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            spriteBatch.Draw(_spriteSheet, new Vector2(0, 0), _animation.GetFrame(), Color.White);

            spriteBatch.End();
        }
    }
}
