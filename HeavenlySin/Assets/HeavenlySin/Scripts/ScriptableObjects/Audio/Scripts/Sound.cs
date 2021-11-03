using UnityEngine;

namespace HeavenlySin.Audio
{
    /// <summary>
    /// This scriptable object holds different sound clips that will be put into
    /// an array for the audio manager. Each clip has an associated audio source
    /// that the SoundType affects. This is so we can change the volume of
    /// SOUND_EFFECTS without changing the volume of MUSIC
    /// </summary>
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