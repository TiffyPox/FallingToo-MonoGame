using System;
using FallingWoman.Graphics;
using FallingWoman.Helpers;
using FallingWoman.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FallingWoman.Screens
{
    internal class StartScreen : BaseScreen
    {
        // Screen where the player is Idle and the user can click 'Start' to begin the cutscene
        
        private Texture2D _spriteSheet;

        private SpriteFont _font;

        private const string Start = "start";
        private const string Title = "\"falling too...\"";

        private Animation _animation;
        
        private float _startTextScale = 1.0f;
        private float _targetTextScale = 1.0f;
        
        private SoundEffect _pop;
        private Rectangle _startTextRectangle;
        
        private readonly SoundSystem _soundSystem;
        private readonly SoundEffectSystem _soundEffectSystem;
        
        private Song _song;

        public StartScreen(SoundSystem soundSystem, SoundEffectSystem soundEffectSystem)
        {
            _soundSystem = soundSystem;
            _soundEffectSystem = soundEffectSystem;
            BackgroundColor = new Color(255, 255, 255, 0);
        }

        public override void Load(ContentManager content)
        {
            _spriteSheet = content.Load<Texture2D>("IdleAnimation-Sheet");
            _font = content.Load<SpriteFont>("AltText");

            _pop = content.Load<SoundEffect>("pop");
            _song = content.Load<Song>("cutsceneMusic");
        }

        public override void Initialize()
        {
            base.Initialize();
            
            _animation = new Animation(new Vector2(300, 500), _spriteSheet.Width / 300);
        }

        public override void OnShow()
        {
            _soundSystem.Play(_song, true);
        }
        
        protected override void OnUpdate(GameTime gameTime)
        {
            _animation.Update(gameTime);

            var startTextSize = _font.MeasureString(Start) * _startTextScale;
            _startTextRectangle = new Rectangle((int) (FallingWoman.ScreenWidth / 2.0f - startTextSize.X / 2.0f), (int) (FallingWoman.ScreenHeight / 2.0f - startTextSize.Y / 2.0f),
                (int) startTextSize.X, (int) startTextSize.Y);
            var mouseRectangle = new Rectangle(CurrentMouseState.X, CurrentMouseState.Y, 1, 1);

            if (mouseRectangle.Intersects(_startTextRectangle))
            {
                if (Math.Abs(_targetTextScale - 2.0f) > 0.01f)
                {
                    _soundEffectSystem.Play(_pop);
                }
                
                _targetTextScale = 2.0f;

                if (CurrentMouseState.LeftButton == ButtonState.Pressed)
                {
                    AddScreen(new CutScene(_soundSystem, _soundEffectSystem));
                }
            }
            else
            {
                _targetTextScale = 1.0f;
            }

            _targetTextScale = mouseRectangle.Intersects(_startTextRectangle) ? 2.0f : 1.0f;
            _startTextScale = MathHelper.Lerp(_startTextScale, _targetTextScale, 0.25f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            spriteBatch.Draw(_spriteSheet, Vector2.Zero, _animation.GetFrame(), Color.White);

            var textSize = _font.MeasureString(Start);
            spriteBatch.DrawString(_font, Start,
                new Vector2(FallingWoman.ScreenWidth / 2.0f, FallingWoman.ScreenHeight / 2.0f), Color.White, 0.0f, textSize * 0.5f, _startTextScale, SpriteEffects.None, 0);
            
            var titleSize = _font.MeasureString(Title);
            spriteBatch.DrawString(_font, Title,
                new Vector2(FallingWoman.ScreenWidth / 2.0f - titleSize.X / 2.0f, FallingWoman.ScreenHeight / 2.0f - titleSize.Y * 2.0f), Color.White);

            if (FallingWoman.Debug)
            {
                DrawHelpers.DrawRectangle(spriteBatch, _startTextRectangle.X, _startTextRectangle.Y, _startTextRectangle.Width, _startTextRectangle.Height, Color.Red, false);    
            }
            
            spriteBatch.End();
        }
    }
}