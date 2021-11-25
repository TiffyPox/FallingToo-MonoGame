using System;
using Microsoft.Xna.Framework;

namespace FallingWoman.Graphics
{
    public class Animation
    {
        public Action OnFinish;
        
        private float _elapsed;
        private const float Delay = 600f;
        private int _frames = 0;
        private readonly Vector2 _frameSize;
        private readonly int _frameCount;
        private readonly bool _looped;
        private bool _finished;

        public Animation(Vector2 frameSize, int frameCount, bool looped = true)
        {
            _frameSize = frameSize;
            _frameCount = frameCount;
            _looped = looped;
        }

        public void Update(GameTime gameTime)
        {
            _elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_elapsed < Delay)
            {
                return;
            }
            
            _frames++;

            if (_frames >= _frameCount)
            {
                if (_looped)
                {
                    _frames = 0;
                    OnFinish?.Invoke();
                }
                else
                {
                    _frames = _frameCount - 1;
                    if (!_finished)
                    {
                        _finished = true;
                        OnFinish?.Invoke();
                    }
                }
            }

            _elapsed = 0;
        }

        internal Rectangle GetFrame() => new Rectangle((int)_frameSize.X * _frames, 0, (int)_frameSize.X, (int)_frameSize.Y);
    }
}