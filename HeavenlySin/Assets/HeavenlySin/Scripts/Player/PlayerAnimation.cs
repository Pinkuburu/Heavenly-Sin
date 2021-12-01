using UnityEngine;

namespace HeavenlySin.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        /// <summary>
        /// This class updates the player's animations
        /// </summary>

        #region Fields
        public PlayerScript playerScript;
        private Animator playerAnim;
        #endregion

        #region LifeCycle
        private void Start()
        {
            playerAnim = GetComponent<Animator>();
        }
        #endregion
    }
}
