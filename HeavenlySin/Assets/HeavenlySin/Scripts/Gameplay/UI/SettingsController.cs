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
            masterVolume.GetComponent<Slider>().onValueChanged.AddListener(delegate{UpdateScriptableObject();});
            sfxVolume.GetComponent<Slider>().onValueChanged.AddListener(delegate{UpdateScriptableObject();});
            musicVolume.GetComponent<Slider>().onValueChanged.AddListener(delegate{UpdateScriptableObject();});
            mouseSens.GetComponent<Slider>().onValueChanged.AddListener(delegate{UpdateScriptableObject();});
            fullscreenToggle.GetComponent<Toggle>().onValueChanged.AddListener(delegate{UpdateScriptableObject();});
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

        public void UpdateScriptableObject()
        {
            settings.audio.masterVolume = masterVolume.GetComponent<Slider>().value;
            settings.audio.sfxVolume = sfxVolume.GetComponent<Slider>().value;
            settings.audio.musicVolume = musicVolume.GetComponent<Slider>().value;
            settings.control.mouseSens = mouseSens.GetComponent<Slider>().value;
            settings.control.isFullscreen = fullscreenToggle.GetComponent<Toggle>().isOn;
        }
        
        #endregion 

        #region Private Methods
        #endregion
    }
}