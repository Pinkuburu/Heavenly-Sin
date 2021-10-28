using HeavenlySin.Audio;
using Unity.VisualScripting;
using UnityEngine;

namespace HeavenlySin.AudioManagement
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
            Debug.Log("Played sound " + sounds[index].clip.name);
        }
        
        #endregion
    }
}