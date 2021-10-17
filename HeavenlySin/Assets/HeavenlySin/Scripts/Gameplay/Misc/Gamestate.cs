using HeavenlySin.GameEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin
{
    public class Gamestate : MonoBehaviour
    {
        #region Fields

        [SerializeField] private IntEvent onSceneLoad;
        
        
        #endregion
 
        #region LifeCycle

        private void OnEnable()
        {
            if (SceneManager.GetActiveScene().name == "Overworld")
            {
                onSceneLoad.Raise(0);
            }
            else if (SceneManager.GetActiveScene().name == "Dreamscape")
            {
                onSceneLoad.Raise(1);
            }
        }
        #endregion

        #region Public Methods
        #endregion 

        #region Private Methods
        #endregion
    }
}