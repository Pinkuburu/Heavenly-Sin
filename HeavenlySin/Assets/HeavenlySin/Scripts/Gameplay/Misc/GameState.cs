using HeavenlySin.Game;
using UnityEngine;

namespace HeavenlySin.Gameplay
{
    public class GameState : MonoBehaviour
    {
        #region Fields

        private static GameState _Instance;
        public GameStateInfo playerState;
        private GameObject _player;
        public SaveLoadManager saveLoadManager;
        #endregion

        #region LifeCycle

        private void Awake()
        {
            if(_Instance != null && _Instance != this)
                Destroy(this.gameObject);
            else
            {
                _Instance = this;
            }
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Start()
        {
            if (playerState.playerPos != null && _player != null)
            {
                _player.transform.position = playerState.playerPos;
            }
        }
        
        #endregion

        #region Public Methods
        
        public void OnSceneChange(Transform playerPos)
        {
            // When the scene is about to change, we want to save the data.
            // This could be called in the main menu as well which would be undesirable, but the if statement should
            // account for that.
            /*if (_player != null)
            {
                playerState.playerPos = playerPos.position;
                saveLoadManager.Save();
            }*/
        }

        public void OnSceneLoad()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            if (playerState.playerPos != null && _player != null)
            {
                _player.transform.position = playerState.playerPos;
            }
        }

        #endregion

        #region Private Methods
        
        private void OnApplicationQuit()
        {
            //saveLoadManager.Save();
        }

        #endregion
    }
}