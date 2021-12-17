using UnityEngine;

namespace HeavenlySin.Gameplay.UI
{
    public class FullScreenToggle : MonoBehaviour
    {
        #region LifeCycle

        public void ToggleFullscreen()
        {
            Screen.fullScreen = !Screen.fullScreen;
        }

        #endregion
    }
}
