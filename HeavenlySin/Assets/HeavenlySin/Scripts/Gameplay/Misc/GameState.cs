using HeavenlySin.Game;
using UnityEngine;

namespace HeavenlySin.Gameplay
{
    public class GameState : MonoBehaviour
    {
        #region Fields

        public GameStateInfo playerState;
        public GameObject player;
        #endregion

        #region LifeCycle

        private void Start()
        {
            if (playerState.playerPos != null)
            {
                player.transform.position = playerState.playerPos.position;
            }
        }

        private void OnApplicationQuit()
        {
            playerState.playerPos = null;
        }

        #endregion

        #region Public Methods

        public void SetTransform(Transform playerPos)
        {
            playerState.playerPos = playerPos;
        }
        
        #endregion

        #region Private Methods

        #endregion
    }
}