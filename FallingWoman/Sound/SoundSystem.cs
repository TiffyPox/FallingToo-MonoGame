using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace FallingWoman.Sound
{
    public class SoundSystem
    {
        private bool _isMuted;

        private bool _hasFinished;

        private SoundEffect _currentSoundEffect;
        private SoundEffectInstance _activeSoundEffect;

        private Song _activeSong;

        public void Play(SoundEffect soundEffect)
        {
            if (_isMuted)
            {
                return;
            }

            if (_currentSoundEffect != null && soundEffect == _currentSoundEffect)
            {
                _activeSoundEffect.Play();
                return;
            }
            
            _activeSoundEffect?.Pause();
            _activeSoundEffect = soundEffect.CreateInstance();
            _activeSoundEffect.Play();
            _currentSoundEffect = soundEffect;
        }        
        
        public void Play(Song song, bool looping = false)
        {
            if (_isMuted)
            {
                return;
            }

            if (_activeSong != null)
            {
                MediaPlayer.Stop();
                return;
            }

            _activeSong = song;
            
            MediaPlayer.IsRepeating = looping;
            MediaPlayer.Play(song);
        }

        public void Stop() => _activeSoundEffect?.Pause();

        public void Start() => _activeSoundEffect.Play();

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