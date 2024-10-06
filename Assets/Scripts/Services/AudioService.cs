using Arkanoid.Utility;
using UnityEngine;
using Utility;

namespace Services
{
    public class AudioService : SingletonMonoBehaviour<AudioService>
    {
        #region Variables

        [SerializeField] private AudioSource _sfxAudioSource;

        #endregion

        #region Public methods

        public void PlaySfx(AudioClip clip)
        {
            if (clip == null)
            {
                return;
            }

            _sfxAudioSource.PlayOneShot(clip);
        }

        public void StopAll()
        {
            _sfxAudioSource.Stop();
        }

        #endregion
    }
}