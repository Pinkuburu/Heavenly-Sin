using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.UI
{
    /// <summary>
    /// This class controls the functionality of buttons and scene switching from the Main Menu
    /// </summary>
    public class MainMenuManager : MonoBehaviour
    {
        #region Public Fields
        #endregion

        #region Public Methods

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void StartNewGame()
        {
            SceneManager.LoadScene("Office");
        }

        public void LoadSavedGame()
        {
            //load from save file, see Sprite Knight scripts
        }

        public void Settings()
        {
            SceneManager.LoadScene("Settings");
        }

        public void Credits()
        {
            SceneManager.LoadScene("Credits");
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
