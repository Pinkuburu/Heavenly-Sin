using Cinemachine;
using UnityEngine;

namespace HeavenlySin.CameraScripts
{
    public class CinemachinePOVExtension : CinemachineExtension
    {
        #region Fields

        [SerializeField] private float horizontalSpeed = 10f;
        [SerializeField] private float verticalSpeed = 10f;
        [SerializeField] private float clampAngle = 80f;
        public InputManager inputManager;
        private Vector3 _startingRotation;
        
        #endregion
 
        #region LifeCycle
        protected override void Awake()
        {
            _startingRotation = transform.localRotation.eulerAngles;
            base.Awake();
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (vcam.Follow)
            {
                if (stage == CinemachineCore.Stage.Aim)
                {
                    var deltaInput = inputManager.InputActions.Overworld.Look.ReadValue<Vector2>();
                    _startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                    _startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                    _startingRotation.y = Mathf.Clamp(_startingRotation.y, -clampAngle, clampAngle);
                    state.RawOrientation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0f);
                }
            }
        }

        private void Start()
        {
        }
 
        private void Update()
        {
        }
        #endregion

        #region Public Methods
        #endregion 

        #region Private Methods
        #endregion
    }
}