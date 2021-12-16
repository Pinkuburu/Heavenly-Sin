using HeavenlySin.GameEvents;
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
        [Tooltip("How much max health the player has")]
        public float health;
        public bool isGrounded;
        [Tooltip("How high the player can jump")]
        public float jumpHeight = 1.7f;
        public PlayerScript playerScript;
        [Tooltip("How fast the player can sprint when holding left shift")]
        public float sprintSpeed;
        [Tooltip("How fast the player can walk")]
        public float walkSpeed = 5f;
        [SerializeField] private IntEvent playerSounds;
        [SerializeField] private IntEvent stopSounds;
        public Vector3 direction;

        #endregion

        #region Private Fields

        private Camera _camera;
        private Vector3 _moveDir = Vector3.zero;
        public bool isJumping;
        private float _speed;
        private float _targetAngle;
        private Vector3 _velocity = Vector3.zero;
        private bool _isSprinting;
        private bool _isFootstepsPlaying;
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
        
        #region Private Methods
        private void CalculateMovement()
        {
            _speed = _isSprinting ? sprintSpeed : walkSpeed;
            // Variables to optimize code.
            var mainCameraTransform = _camera.transform;
            var mainCameraTransformEulerAngles = mainCameraTransform.eulerAngles;

            // Makes player move in relation to the direction they are facing.
            _moveDir = Quaternion.Euler(0f, mainCameraTransformEulerAngles.y, 0f) * direction;
            
            // Lerp angle rotation.
            var angle = Mathf.LerpAngle(transform.eulerAngles.y, _targetAngle, SMOOTH * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, angle, 0);

            // Reset the velocity that it has accumulated while on the ground.
            if (isGrounded && _velocity.y < 0f)
            {
                _velocity.y = -0.5f;
            }
            
            // Jump Calculations.
            if (isJumping && isGrounded)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY);
                playerSounds.Raise(10); //Jump SFX
                var randNum = Random.Range(0, 2);
                playerSounds.Raise(22 + randNum); //Jump vocal SFX
            }
            _velocity.y += GRAVITY * Time.deltaTime;
            characterController.Move(_velocity * Time.deltaTime);
        
            if (isGrounded)
            {
                if(direction.magnitude > 0f)
                {
                    if(!_isFootstepsPlaying)
                    {
                        playerSounds.Raise(16); //Play footsteps SFX
                        _isFootstepsPlaying = true;
                    }
                }
                else
                {
                    if (_isFootstepsPlaying)
                    {
                        stopSounds.Raise(16); //Play footsteps SFX
                        _isFootstepsPlaying = false;
                    }
                }

                characterController.stepOffset = 0.3f;
                characterController.Move(_speed * Time.deltaTime * _moveDir);
            }
            // If not grounded (or most likely jumping), change movement.
            else 
            {
                if (_isFootstepsPlaying)
                {
                    stopSounds.Raise(16); //Play footsteps SFX
                    _isFootstepsPlaying = false;
                }
                characterController.stepOffset = 0f;
                characterController.Move(JUMP_CONTROL_MODIFIER * _speed * Time.deltaTime * _moveDir);
            }
        }
        
        private void MovePlayer()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            
            direction = new Vector3(playerScript.playerInput.move.ReadValue<Vector2>().x, 0f,
                playerScript.playerInput.move.ReadValue<Vector2>().y).normalized;
            isJumping = playerScript.playerInput.inputManager.InputActions.Overworld.Jump.triggered;
            _isSprinting = playerScript.playerInput.isSprinting;
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
