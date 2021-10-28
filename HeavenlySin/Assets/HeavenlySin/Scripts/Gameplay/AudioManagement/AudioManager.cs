using HeavenlySin.Audio;
using UnityEngine;

namespace HeavenlySin.AudioManagement
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource[] sources;
        public Sound[] sounds;
        
        public void PlaySound(AudioSource audioSource, AudioClip[] clips, int index)
        {
            sources[(int)sounds[index].soundType].PlayOneShot(sounds[index].clip);
        }
        
        public void PlaySound(int index)
        {
            sources[(int)sounds[index].soundType].PlayOneShot(sounds[index].clip);
            Debug.Log("Played sound " + sounds[index].clip.name);
        }
    }
}