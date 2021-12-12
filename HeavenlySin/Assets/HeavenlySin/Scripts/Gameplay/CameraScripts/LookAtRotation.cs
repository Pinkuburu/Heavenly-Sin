using UnityEngine;

namespace HeavenlySin.Gameplay.CameraScripts
{
    public class LookAtRotation : MonoBehaviour
    {
        /// <summary>
        /// Rotates the gameObject with this script with the movement of the mouse.
        /// This should be on the "CameraLookAt" child gameObject to the player
        /// The First Person Cinemachine camera has this object as its LookAt field.
        /// </summary>
        #region Fields

        [Tooltip("How far the player can look up/down before being stopped")]
        [SerializeField] private float clampAngle = 80f;
        [Tooltip("Horizontal mouse sensitivity")]
        [SerializeField] private float horizontalSpeed = 10f;
        [Tooltip("Vertical mouse sensitivity")]
        [SerializeField] private float verticalSpeed = 10f;
        
        public InputManager inputManager;
        private Vector3 _startingRotation;
        
        #endregion
 
        #region LifeCycle
        private void Awake()
        {
            _startingRotation = transform.localRotation.eulerAngles;
        }
 
        private void Update()
        {
            // Get values from input system.
            var deltaInput = inputManager.InputActions.Overworld.Look.ReadValue<Vector2>();
            _startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
            _startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
            // Clamp the y rotation so the camera doesn't wrap around when looking up or down.
            _startingRotation.y = Mathf.Clamp(_startingRotation.y, -clampAngle, clampAngle);
            // Change object's rotation.
            transform.rotation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0f);
        }
        #endregion
    }
}