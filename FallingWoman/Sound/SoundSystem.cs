using Microsoft.Xna.Framework.Media;

namespace FallingWoman.Sound
{
    public class SoundSystem
    {
        private bool _isMuted;

        private Song _activeSong;    
        
        public void Play(Song song, bool looping = false)
        {
            if (_isMuted)
            {
                return;
            }

            if (_activeSong != null && _activeSong == song) 
            {
                return;
            }

            MediaPlayer.IsRepeating = looping;
            MediaPlayer.Play(song);
            _activeSong = song;
        }

        private void Stop()
        {
            _activeSong = null;
            MediaPlayer.Stop();
        }

        private void Start() => MediaPlayer.Play(_activeSong);

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
    }
}