using UnityEngine;
using UnityEngine.UI;

namespace HeavenlySin.UI
{
    /// <summary>
    /// This class will Enable and Disable the necessary UI elements
    /// It does this by listening for certain events
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        #region Public Fields

        public Image[] uiElements;
        #endregion

        #region Public Methods

        public void Update()
        {
            //Pausing and resuming the game state
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }

        public void DisableImage(int index)
        {
            uiElements[index].enabled = false;
        }
        
        public void EnableImage(int index)
        {
            uiElements[index].enabled = true;
        }
        
        #endregion 

        #region Private Methods
        #endregion
    }
}