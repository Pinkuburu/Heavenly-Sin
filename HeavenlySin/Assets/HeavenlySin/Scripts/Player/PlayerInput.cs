using UnityEngine;
using UnityEngine.InputSystem;

namespace HeavenlySin.Player
{
    /// <summary>
    /// The PlayerInput class takes and stores all the keyboard/controller
    /// input. Anything that uses this input has to go through PlayerScript
    /// to get to it.
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        public InputManager inputManager;
        public PlayerScript playerScript;
        public SpriteRenderer sprite;
                                                              
        [HideInInspector] public InputAction move;
        
        #region Life Cycle

        private void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }

        private void OnEnable()
        {
            inputManager.ActionMapChange += CheckEnabledActionMap;
        }

        private void OnDisable()
        {
            DisableActionMap();
        }
        
        #endregion
        
        #region Private Methods
        private void CheckEnabledActionMap(InputActionMap actionMap)
        {
            if (actionMap == (InputActionMap)inputManager.InputActions.Overworld)
            {
                EnableActionMap();
            }
            else
            {
                DisableActionMap();
            }
        }
        
        private void DisableActionMap()
        {
            move.Disable();
            inputManager.InputActions.Overworld.Interact.performed -= DoInteract;
        }
        
        private void DisableSprite()
        {
            sprite.enabled = false;
        }
        
        private void DoInteract(InputAction.CallbackContext obj)
        {
            playerScript.playerCollision.currentTarget?.Interact();
        }

        private void EnableActionMap()
        {
            move = inputManager.InputActions.Overworld.Movement;
            move.Enable();
            inputManager.InputActions.Overworld.Interact.performed += DoInteract;
            
            inputManager.InputActions.Overworld.Enable();
        }
        #endregion
    }
}
