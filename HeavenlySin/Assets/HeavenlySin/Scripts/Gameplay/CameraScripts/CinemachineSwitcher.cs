using UnityEngine;

namespace HeavenlySin.CameraScripts
{
    public class CinemachineSwitcher : MonoBehaviour
    {
        /// <summary>
        /// Switches the animation states of the animator
        /// that controls which Cinemachine camera is active.
        /// </summary>
        #region Fields

        public Animator animator;
        private bool _isOverworldCamera = true;
        
        #endregion
 
        #region LifeCycle
        private void Update()
        {
            // Debug statement to test camera transitions.
            if (Input.GetKeyDown(KeyCode.T))
            {
                SwitchState();
            }
        }
        #endregion
        
        #region Private Methods
        private void SwitchState()
        {
            if (_isOverworldCamera)
            {
                animator.Play("Combat");
            }
            else
            {
                animator.Play("Overworld");
            }
            _isOverworldCamera = !_isOverworldCamera;
        }
        #endregion
    }
}