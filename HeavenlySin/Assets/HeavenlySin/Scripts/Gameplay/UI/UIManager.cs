using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        public GameObject[] uiMenus;

        #endregion

        #region Public Methods

        public void Start()
        {
            uiMenus[0].SetActive(false); //pause menu
            uiMenus[1].SetActive(false); //settings menu
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseResume();
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
        public void PauseResume()
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                EnableMenu(0);
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                DisableMenu(0);
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

        public void QuitGame()
        {
            if(SceneManager.GetActiveScene().name != "MainMenu")
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                Application.Quit();
            }
        }
        
        #endregion 

        #region Private Methods
        #endregion
    }
}