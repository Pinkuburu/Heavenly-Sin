using UnityEngine;
using HeavenlySin.GameEvents;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Gameplay
{
    public class ReloadLevel : MonoBehaviour
    {
        #region Fields
        public int soundIndex;
        [SerializeField] private IntEvent onPlaySound;
        #endregion
 
        #region LifeCycle
        private void Awake()
        {
        }

        private void Start()
        {
        }
 
        private void Update()
        {
        }
        #endregion

        #region Public Methods
        #endregion 

        #region Private Methods

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                onPlaySound.Raise(soundIndex);
                ReloadScene();
            }
        }

        private static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion
    }
}