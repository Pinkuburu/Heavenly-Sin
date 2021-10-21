using UnityEngine;

namespace HeavenlySin.Audio
{
    [CreateAssetMenu(fileName = "New AudioManager", menuName = "ScriptableObjects/AudioManager")]
    public class AudioManager : ScriptableObject
    {
        public AudioClip[] sounds;

        public void PlayRandomSound(AudioSource audioSource, AudioClip[] clips, int index)
        {
            audioSource.PlayOneShot(clips[index]);
        }
        
        public void PlayRandomSound(AudioSource audioSource, int index)
        {
            audioSource.PlayOneShot(sounds[index]);
        }
    }
}