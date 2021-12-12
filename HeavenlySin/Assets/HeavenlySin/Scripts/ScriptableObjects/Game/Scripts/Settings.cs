using UnityEngine;

namespace HeavenlySin.Game
{
    [CreateAssetMenu(fileName = "New Settings", menuName = "ScriptableObjects/Settings")]
    public class Settings : ScriptableObject
    {
        public AudioSettings audio;
        public ControlSettings control;
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

    [System.Serializable]
    public class ControlSettings
    {
        public float mouseSens;
        public bool isFullscreen;
    }
}