using UnityEngine;

namespace HeavenlySin.Sound
{
    [CreateAssetMenu(fileName = "New SoundManager", menuName = "ScriptableObjects/SoundManager")]
    public class SoundManager : ScriptableObject
    {
        public AudioClip[] sounds;

        public void PlayRandomSound(AudioClip[] arr, int index)
        {
            
        }
        
        public void PlayRandomSound(int index)
        {
            
        }
    }
}