using Microsoft.Xna.Framework.Audio;

namespace FallingWoman.Sound
{
    public class SoundEffectSystem
    {
        private bool _isMuted;

        private SoundEffect _currentSoundEffect;
        private SoundEffectInstance _activeSoundEffect;
        
        public void Play(SoundEffect soundEffect)
        {
            if (_isMuted)
            {
                return;
            }

            if (_currentSoundEffect != null && soundEffect == _currentSoundEffect)
            {
                _activeSoundEffect?.Play();
                return;
            }

            _activeSoundEffect?.Pause();
            _activeSoundEffect = soundEffect.CreateInstance();
            _activeSoundEffect.Play();
            _currentSoundEffect = soundEffect;
        }

        private void Stop()
        {
            _activeSoundEffect?.Pause();
        }

        private void Start() => _activeSoundEffect?.Play();

        public void Mute(bool isMuted)
        {
            _isMuted = isMuted;

            if (isMuted)
            {
                Stop();
            }
            else
            {
                Start();
            }
        }
        
        public void Restart() => _activeSoundEffect = _currentSoundEffect.CreateInstance();
    }
}