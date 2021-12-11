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
        
        public void PlaySound(AudioSource audioSource, AudioClip[] clips, int index)
        {
            sources[(int)sounds[index].soundType].PlayOneShot(sounds[index].clip);
        }
        
        public void PlaySound(int index)
        {
            sources[(int)sounds[index].soundType].PlayOneShot(sounds[index].clip);
        }
        
        #endregion
    }
    
    [System.Serializable]
    public class AudioSettings
    {
        public float masterVolume;
        public float sfxVolume;
        public float musicVolume;

        public AudioSettings(float masterVolume, float sfxVolume, float musicVolume)
        {
            this.masterVolume = masterVolume;
            this.sfxVolume = sfxVolume;
            this.musicVolume = musicVolume;
        }

        public AudioSettings(AudioSettings audioSettings)
        {
            this.masterVolume = audioSettings.masterVolume;
            this.sfxVolume = audioSettings.sfxVolume;
            this.musicVolume = audioSettings.musicVolume;
        }

        public AudioSettings()
        {
            this.masterVolume = 0.5f;
            this.sfxVolume = 0.5f;
            this.musicVolume = 0.5f;
        }
    }
}