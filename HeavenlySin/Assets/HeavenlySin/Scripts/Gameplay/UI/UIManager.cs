using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HeavenlySin.Gameplay.UI
{
    /// <summary>
    /// This class will Enable and Disable the necessary UI elements
    /// It does this by listening for certain events
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        #region Public Fields

        public Image[] uiElements;
        public GameObject[] uiMenus;

        #endregion

        #region Public Methods

        public void Start()
        {
            // All Menus Disabled
            for (int i = 0; i < uiMenus.Length; i++)
            {
                uiMenus[i].SetActive(false);
            }
        }

        public void Update()
        {
            // Pause Menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseResume(0);
            } 
            // Map
            if (Input.GetKeyDown(KeyCode.M))
            {
                PauseResume(2);
            }
        }

        //UI Menus
        public void EnableMenu(int index)
        {
            uiMenus[index].SetActive(true);
        }

        public void DisableMenu(int index)
        {
            uiMenus[index].SetActive(false);
        }

        public int DisableAllMenus()
        {
            int disabledMenu = -1;
            for (var i = 0; i < uiMenus.Length; i++)
            {
                if (uiMenus[i].activeSelf)
                    disabledMenu = i;
                DisableMenu(i);
            }

            return disabledMenu;
        }

        //UI Elements
        public void EnableImage(int index)
        {
            uiElements[index].enabled = true;
        }
        public void DisableImage(int index)
        {
            uiElements[index].enabled = false;
        }

        //Pausing and resuming the state of the game, and hiding/showing proper elements
        public void PauseResume(int index)
        {
            var otherMenu = DisableAllMenus();
            
            if(otherMenu != index)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                EnableMenu(index);
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        public void Settings()
        {
            if(uiMenus[1].activeSelf == false)
            {
                uiMenus[0].SetActive(false);
                uiMenus[1].SetActive(true);
            }
            else
            {
                uiMenus[0].SetActive(true);
                uiMenus[1].SetActive(false);
            }
        }
        
        public void QuitToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        
        #endregion 

        #region Private Methods
        #endregion
    }
}