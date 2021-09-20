using HeavenlySin.Interactable;
using UnityEngine;

namespace HeavenlySin.Player
{
    /// <summary>
    /// This class will take care of all player collision
    /// and trigger detection.
    /// </summary>

    public class PlayerCollision : MonoBehaviour
    {
        #region Public Fields
        public PlayerScript playerScript;
        [Tooltip("The maximum distance players can interact with interactable objects.")]
        [Range(0, 20)]public float range;
        #endregion
        
        #region Private Fields
        private Camera _camera;
        private IInteractable _currentTarget;
        #endregion
        
        #region Life Cycle
        
        private void Start()
        {
            _camera = Camera.main;
        }
        private void Update()
        {
            RaycastForInteractable();
        }
        
        #endregion
        
        #region Private Methods
        private void RaycastForInteractable()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            // Cast a ray from the camera to the mouse (middle of the screen).
            if (Physics.Raycast(ray, out var hit, range))
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                // The ray hit an interactable object.
                if (interactable != null)
                {
                    if (hit.distance <= interactable.MaxRange)
                    {
                        if (interactable == _currentTarget)
                            return;
                        if (_currentTarget != null)
                        {
                            _currentTarget.OnEndHover();
                            _currentTarget = interactable;
                            _currentTarget.OnStartHover();
                            return;
                        }

                        _currentTarget = interactable;
                        _currentTarget.OnStartHover();
                    }
                    // If the object is still further than their individual max interaction range, make the target null.
                    else
                    {
                        if (_currentTarget != null)
                        {
                            _currentTarget.OnEndHover();
                            _currentTarget = null;
                        }
                    }
                }
                else
                {
                    if (_currentTarget == null)
                        return;
                    _currentTarget.OnEndHover();
                    _currentTarget = null;
                }
            }
            // If the ray does not hit anything, make the current target null.
            else
            {
                if (_currentTarget == null)
                    return;
                _currentTarget.OnEndHover();
                _currentTarget = null;
            }
        }
        #endregion
    }
    
}
