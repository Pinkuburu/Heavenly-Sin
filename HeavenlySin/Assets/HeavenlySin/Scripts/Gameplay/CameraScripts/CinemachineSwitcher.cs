using UnityEngine;

namespace HeavenlySin.Gameplay.CameraScripts
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

        private void Start()
        {
            SwitchState();
        }
        #endregion
        
        #region Private Methods
        private void SwitchState()
        {
            animator.Play(_isOverworldCamera ? "Combat" : "Overworld");
            _isOverworldCamera = !_isOverworldCamera;
        }
        #endregion
    }
}