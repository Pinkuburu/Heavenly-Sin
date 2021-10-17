using UnityEngine;

namespace HeavenlySin.Player
{
    /// <summary>
    /// Calculates all player movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        #region Constant Fields
        
        private const float GRAVITY = -20f;
        private const float JUMP_CONTROL_MODIFIER = 0.7f;
        private const float SMOOTH = 10f;
        
        #endregion

        #region Public Fields
        
        public CharacterController characterController;
        public Transform groundCheck;
        [Tooltip("The height away from groundCheck that the player must be in order to be grounded")]
        public float groundDistance;
        [Tooltip("The layer that the player can be grounded on")]
        public LayerMask groundMask;
        public bool isGrounded;
        [Tooltip("How high the player can jump")]
        public float jumpHeight = 1.7f;
        public PlayerScript playerScript;
        [Tooltip("How fast the player can move")]
        public float speed = 5f;
        
        #endregion
        
        #region Private Fields
        
        private Camera _camera;
        private Vector3 _direction;
        private Vector3 _moveDir = Vector3.zero;
        private bool _isOverworld = true;
        private bool _isJumping;
        private float _targetAngle;
        private Vector3 _velocity = Vector3.zero;
        
        #endregion
        
        #region Life Cycle
        
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            MovePlayer();
        }
        
        #endregion
        
        #region Public Methods
        
        public void ChangeMovement(int num)
        {
            if (num == 0)
            {
                playerScript.playerInput.inputManager.ToggleActionMap(playerScript.playerInput.inputManager
                    .InputActions.Overworld);
                _isOverworld = true;
            }
            else if(num == 1)
            {
                playerScript.playerInput.inputManager.ToggleActionMap(playerScript.playerInput.inputManager
                        .InputActions.Combat);
                playerScript.playerInput.sprite.enabled = true;
                _isOverworld = false;
            }
        }
        
        #endregion
        
        #region Private Methods
        private void CalculateMovement()
        {
            // Variables to optimize code.
            var mainCameraTransform = _camera.transform;
            var mainCameraTransformEulerAngles = mainCameraTransform.eulerAngles;

            // Makes player move in relation to the direction they are facing.
            _moveDir = Quaternion.Euler(0f, mainCameraTransformEulerAngles.y, 0f) * _direction;
            
            // Lerp angle rotation.
            var angle = Mathf.LerpAngle(transform.eulerAngles.y, _targetAngle, SMOOTH * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, angle, 0);

            // Reset the velocity that it has accumulated while on the ground.
            if (isGrounded && _velocity.y < 0f)
            {
                _velocity.y = -0.5f;
            }
            
            // Jump Calculations.
            if (_isJumping && isGrounded)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY);
            }
            _velocity.y += GRAVITY * Time.deltaTime;
            characterController.Move(_velocity * Time.deltaTime);
        
            if (isGrounded)
            {
                characterController.stepOffset = 0.3f;
                characterController.Move(speed * Time.deltaTime * _moveDir);
            }
            // If not grounded (or most likely jumping), change movement.
            else 
            {
                characterController.stepOffset = 0f;
                characterController.Move(JUMP_CONTROL_MODIFIER * speed * Time.deltaTime * _moveDir);
            }
        }
        
        private void MovePlayer()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            //Change movement based on the enabled action map
            if (_isOverworld)
            {
                _direction = new Vector3(playerScript.playerInput.move.ReadValue<Vector2>().x, 0f,
                    playerScript.playerInput.move.ReadValue<Vector2>().y).normalized;
                _isJumping = playerScript.playerInput.inputManager.InputActions.Overworld.Jump.triggered;
            }
            else
            {
                _direction = new Vector3(
                        playerScript.playerInput.inputManager.InputActions.Combat.Movement.ReadValue<Vector2>().x, 0f,
                        playerScript.playerInput.inputManager.InputActions.Combat.Movement.ReadValue<Vector2>().y)
                    .normalized;
                _isJumping = playerScript.playerInput.inputManager.InputActions.Combat.Jump.triggered;
            }

            CalculateMovement();
        }
        #endregion

        #region Debug Methods
        
        /*private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }*/
        
        #endregion
    }
}
