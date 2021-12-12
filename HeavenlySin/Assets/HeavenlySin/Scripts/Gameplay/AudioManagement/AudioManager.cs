using HeavenlySin.Audio;
using UnityEngine;

namespace HeavenlySin.Gameplay.AudioManagement
{
    /// <summary>
    /// This class will handle all the sound and music in the game.
    /// When other classes need to play a sound or song, it will send an event that
    /// this class listens for. It will also handle adjustments to volume and other
    /// settings.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        #region Public Fields
        
        public Sound[] sounds;
        public AudioSource[] sources;

        #endregion
        
        #region Public Methods
        
        public void PlaySound(int index)
        {
            if (sounds[index].soundType == SoundType.MUSIC)
            {
                sources[(int)sounds[index].soundType].clip = sounds[index].clip;
                sources[(int)sounds[index].soundType].Play();
            }
            else if(sounds[index].soundType == SoundType.SOUND_EFFECT)
            {
                sources[(int)sounds[index].soundType].PlayOneShot(sounds[index].clip);
            }
            else
            {
                sources[(int)sounds[index].soundType].clip = sounds[index].clip;
                sources[(int)sounds[index].soundType].Play();
            }
        }

        public void StopSound(int index)
        {
            sources[(int)sounds[index].soundType].Pause();
        }
        
        #endregion
    }
}