using HeavenlySin.Game;
using UnityEngine;
using UnityEngine.UI;

namespace HeavenlySin.Gameplay.UI
{
    public class SettingsController : MonoBehaviour
    {
        #region Public Fields

        public Settings settings;
        public GameObject masterVolume;
        public GameObject sfxVolume;
        public GameObject musicVolume;
        public GameObject mouseSens;
        public GameObject fullscreenToggle;

        #endregion
 
        #region LifeCycle
        private void Awake()
        {
            UpdateUI();
        }

        private void Start()
        {
        }
 
        private void Update()
        {
        }
        #endregion

        #region Public Methods

        public void UpdateUI()
        {
            masterVolume.GetComponent<Slider>().value = settings.audio.masterVolume;
            sfxVolume.GetComponent<Slider>().value = settings.audio.sfxVolume;
            musicVolume.GetComponent<Slider>().value = settings.audio.musicVolume;
            mouseSens.GetComponent<Slider>().value = settings.control.mouseSens;
            fullscreenToggle.GetComponent<Toggle>().isOn = settings.control.isFullscreen;
        }
        
        #endregion 

        #region Private Methods
        #endregion
    }
}