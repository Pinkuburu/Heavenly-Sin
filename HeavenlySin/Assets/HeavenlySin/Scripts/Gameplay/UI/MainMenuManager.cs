using HeavenlySin.Game;
using HeavenlySin.GameEvents;
using HeavenlySin.Scene.Scripts;
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
        [SerializeField] private VoidEvent onFadeStart;
        public GameStateInfo gameState;
        #endregion

        #region Public Methods

        public void MainMenu()
        {
            SceneManager.LoadScene((int)Scenes.MAIN_MENU);
        }

        public void StartNewGame()
        {
            onNewGame.Raise();
            onFadeStart.Raise();
            Invoke(nameof(TransitionScene), 1f);
        }

        public void LoadSavedGame()
        {
            onLoadGame.Raise();
            onFadeStart.Raise();
            Invoke(nameof(TransitionScene), 1f);
        }

        public void TransitionScene()
        {
            SceneManager.LoadScene((int)gameState.sceneIndex);
        }
        
        public void Settings()
        {
            SceneManager.LoadScene((int)Scenes.SETTTINGS);
        }

        public void Credits()
        {
            SceneManager.LoadScene((int)Scenes.CREDITS);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        #endregion
    }
}
