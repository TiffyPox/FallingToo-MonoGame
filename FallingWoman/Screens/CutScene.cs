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

        private Color _color;

        private bool _screenEnded;
        
        private const float MaxTime = 3.0f;
        private float _currentTime = MaxTime;
        private SpriteFont _font;

        public CutScene()
        {
            BackgroundColor = new Color(255, 255, 255, 0);
        }

        public override void Load(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("FallingAnimation-Sheet");
            _font = content.Load<SpriteFont>("AltText");
        }

        public override void Initialize()
        {
            base.Initialize();

            _color = new Color(255, 255, 255);

            _animation = new Animation(new Vector2(300, 500), _spriteSheet.Width / 300, false)
            {
                OnFinish = () =>
                {
                    _screenEnded = true;
                }
            };
        }

        public override void OnShow()
        {
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            _animation.Update(gameTime);
            
            if (_animation.GetFrameNumber() > 10 && _animation.GetFrameNumber() < 19)
            {
                _rotation = _rotation == 1 ? -1 : 1;
            }
            else
            {
                _rotation = 0;
            }
            
            if (!_screenEnded) return;
            
            _currentTime -= (float) gameTime.ElapsedGameTime.TotalSeconds;
            var currentAlpha = (_currentTime / MaxTime) * 255;
            _color.A = (byte) currentAlpha;
                
            if (_currentTime <= 0)
            {
                AddScreen?.Invoke(new GameScreen());
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: GetMatrix());

            spriteBatch.Draw(_spriteSheet, new Vector2(0, 0), _animation.GetFrame(), _color);

            spriteBatch.End();
        }

        private int _rotation = 0;

        private Matrix GetMatrix()
        {
            return
                Matrix.CreateTranslation(-new Vector3(_animation.GetFrame().Width / 2.0f,
                    _animation.GetFrame().Height / 2.0f, 0))
                * Matrix.CreateRotationZ(MathHelper.ToRadians(_rotation * 0.5f))
                * Matrix.CreateTranslation(new Vector3(_animation.GetFrame().Width / 2.0f,
                    _animation.GetFrame().Height / 2.0f, 0));
        }
    }
}
