using UnityEngine;
using UnityEngine.UI;

namespace HeavenlySin.Gameplay.UI
{
    public class FullScreenToggle : MonoBehaviour
    {
        #region Fields

        public Toggle fullscreenToggle;
        private bool _isCorrect;

        #endregion

        #region LifeCycle

        private void Start()
        {
            if(Screen.fullScreen)
            {
                _isCorrect = true;
                fullscreenToggle.isOn = Screen.fullScreen;
            }
        }

        public void ToggleFullscreen()
        {
            if(!_isCorrect)
            {
                Screen.fullScreen = !Screen.fullScreen;
            }
            else
            {
                _isCorrect = false;
            }
        }

        #endregion
    }
}
