using UnityEngine;

namespace HeavenlySin.Audio
{
    [CreateAssetMenu(fileName = "New Sound", menuName = "ScriptableObjects/Sound")]
    public class Sound : ScriptableObject
    {
        public AudioClip clip;
        public SoundType soundType;
    }

    public enum SoundType
    {
        MUSIC,
        SOUND_EFFECT,
        ENVIRONMENT
    };
}