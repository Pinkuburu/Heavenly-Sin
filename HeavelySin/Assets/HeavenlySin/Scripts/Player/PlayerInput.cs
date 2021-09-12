using UnityEngine;
using UnityEngine.InputSystem;

namespace HeavenlySin.Player
{
    public class PlayerInput : MonoBehaviour
    {
        /// <summary>
        /// The PlayerInput class takes and stores all the keyboard/controller
        /// input. Anything that uses this input has to go through PlayerScript
        /// to get to it.
        /// </summary>
        public InputManager inputManager;
        public PlayerScript playerScript;
        
        [HideInInspector] public InputAction move;
        
        #region Life Cycle
        private void Start()
        {
            inputManager.ActionMapChange += CheckEnabledActionMap;
        }

        private void OnEnable()
        {
            EnableActionMap();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnDisable()
        {
            DisableActionMap();
        }
        
        #endregion
        
        private void CheckEnabledActionMap(InputActionMap actionMap)
        {
            if (actionMap == (InputActionMap)inputManager.InputActions.Overworld)
            {
                EnableActionMap();
            }
        }
        
        private void DisableActionMap()
        {
            move.Disable();
        }

        private void EnableActionMap()
        {
            move = inputManager.InputActions.Overworld.Movement;
            move.Enable();
            inputManager.InputActions.Overworld.Enable();
        }
    }
}
