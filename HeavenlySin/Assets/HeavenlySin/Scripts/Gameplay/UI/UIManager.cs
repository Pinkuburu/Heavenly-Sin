using System.Collections;
using System.Collections.Generic;
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

        // Journal variables
        public int pageIndex; // Total amount of pages: 8
        public GameObject frontPageButton;
        public GameObject backPageButton;
        public Text firstPageTitle, secondPageTitle, secondPageText;
        public Text firstPageTitleOutline, secondPageTitleOutline, secondPageTextOutline;

        public GameObject[] characterPortraits;

        List<string> firstPageTitles = new List<string>()
        {
            "Null", // First Page
            "VICTIM",
            "SUSPECT #1",
            "SUSPECT #2",
            "SUSPECT #3",
            "SUSPECT #4",
            "SUSPECT #5",
            "SUSPECT #6" // Last Page
        };

        List<string> secondPageTitles = new List<string>()
        {
            "OBJECTIVE", // First Page
            "WES",
            "PENELOPE",
            "LANCE",
            "ESMERELDA",
            "GERARDO",
            "GIANA",
            "SAL" // Last Page
        };

        #endregion

        #region Public Methods

        public void Start()
        {
            // Starts Journal on First Page: Objective
            pageIndex = 0;

            // All Character Portraits Disabled
            for (int i = 0; i < characterPortraits.Length; i++)
            {
                characterPortraits[i].SetActive(false);
            }

            frontPageButton.SetActive(false);
            UpdateFirstPageTitle();
            UpdateSecondPageTitle();

            firstPageTitle.enabled = false;
            firstPageTitleOutline.enabled = false;

            // All Menus Disabled
            for (int i = 0; i < uiMenus.Length; i++)
            {
                uiMenus[i].SetActive(false);
            }

            // Older code review: given uiMenu now has grown, threw it into a for loop
            /*
            uiMenus[0].SetActive(false); //pause menu
            uiMenus[1].SetActive(false); //settings menu
            uiMenus[2].SetActive(false); //map menu
            uiMenus[3].SetActive(false); //journal menu
            */
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
                PauseResume(1);
            } 
            // Journal
            if (Input.GetKeyDown(KeyCode.J))
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

        public void DisableAllMenus()
        {
            for (int i = 0; i < uiMenus.Length; i++)
            {
                DisableMenu(i);
            } 
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

        public void DisableAllCharacterPortraits()
        {
            for (int i = 0; i < characterPortraits.Length; i++)
            {
                characterPortraits[i].SetActive(false);
            }
        }

        public void UpdateFirstPageTitle()
        {
            firstPageTitle.text = firstPageTitles[pageIndex]; 
            firstPageTitleOutline.text = firstPageTitles[pageIndex]; 
        }

        public void UpdateSecondPageTitle()
        {
            secondPageTitle.text = secondPageTitles[pageIndex]; 
            secondPageTitleOutline.text = secondPageTitles[pageIndex]; 
        }

        //Pausing and resuming the state of the game, and hiding/showing proper elements
        public void PauseResume(int index)
        {
            DisableAllMenus();

            if(Time.timeScale == 1)
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
                DisableMenu(index);
            }
        }

        public void Settings()
        {
            if(uiMenus[3].activeSelf == false)
            {
                uiMenus[0].SetActive(false);
                uiMenus[3].SetActive(true);
            }
            else
            {
                uiMenus[0].SetActive(true);
                uiMenus[3].SetActive(false);
            }
        }

        public void Journal()
        {
            DisableAllCharacterPortraits();
            UpdateFirstPageTitle();
            UpdateSecondPageTitle();

            if (pageIndex == 0) // Objective
            {
                frontPageButton.SetActive(false);
                firstPageTitle.enabled = false;
                firstPageTitleOutline.enabled = false;
            }
            if (pageIndex == 1) // Victim Analysis
            {
                frontPageButton.SetActive(true);

                firstPageTitle.enabled = true;
                firstPageTitleOutline.enabled = true;
                characterPortraits[0].SetActive(true);
            }
            if (pageIndex == 2) // Pride Analysis
            {
                characterPortraits[1].SetActive(true);
            }
            if (pageIndex == 3) // Lust Analysis
            {
                characterPortraits[2].SetActive(true);
            }
            if (pageIndex == 4) // Envy Analysis
            {
                characterPortraits[3].SetActive(true);
            }
            if (pageIndex == 5) // Greed Analysis
            {
                characterPortraits[4].SetActive(true);
            }
            if (pageIndex == 6) // Gluttony Analysis
            {
                backPageButton.SetActive(true);
                characterPortraits[5].SetActive(true);
            }
            if (pageIndex == 7) // Sloth Analysis
            {
                backPageButton.SetActive(false);
                characterPortraits[6].SetActive(true);
            }

        }

        public void FrontPageNext()
        {
            pageIndex--;
            Journal();
        }

        public void BackPageNext()
        {
            pageIndex++;
            Journal();
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