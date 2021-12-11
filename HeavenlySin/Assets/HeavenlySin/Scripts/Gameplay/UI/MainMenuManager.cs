using HeavenlySin.Game;
using HeavenlySin.GameEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Gameplay.UI
{
    /// <summary>
    /// This class controls the functionality of buttons and scene switching from the Main Menu
    /// </summary>
    public class MainMenuManager : MonoBehaviour
    {
        #region Public Fields

        [SerializeField] private VoidEvent onNewGame;
        [SerializeField] private VoidEvent onLoadGame;
        public GameStateInfo gameStateInfo;
        #endregion

        #region Public Methods

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void StartNewGame()
        {
            //SceneManager.LoadScene("Office");
            onNewGame.Raise();
            SceneManager.LoadScene((int)gameStateInfo.sceneIndex);
        }

        public void LoadSavedGame()
        {
            //load from save file, see Sprite Knight scripts
            onLoadGame.Raise();
            SceneManager.LoadScene((int)gameStateInfo.sceneIndex);
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
