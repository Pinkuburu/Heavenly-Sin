using System;
using UnityEngine;
using UnityEngine.UI;

namespace HeavenlySin.Shooting
{
    /// <summary>
    /// This class handles the UI representation of the player's ammo.
    /// It receives events when the player shoots or reloads to accomplish this.
    /// </summary>
    public class Cylinder : MonoBehaviour
    {
        #region Public Fields

        public Image[] bullets;
        [Tooltip("Control the rotation direction of the cylinder image.")]
        public bool isClockwiseRotation;
        [Tooltip("How quickly the cylinder rotates to its next position.")]
        [Range(1, 20)]public float rotationSpeed;

        #endregion

        #region Private Fields

        private const int CYLINDER_ROTATION = 60;
        private bool _isRotating;
        private float _targetAngle = 30f;

        #endregion
        
        #region LifeCycle

        private void Update()
        {
            if (!_isRotating)
                return;
            LerpCylinderRotation();
        }

        #endregion

        #region Public Methods

        public void FireBullet(int index)
        {
            // Disable the correct bullet and rotate the cylinder.
            if (isClockwiseRotation)
            {
                bullets[bullets.Length - index].enabled = false;
                _targetAngle -= CYLINDER_ROTATION;
            }
            else
            {
                bullets[index % bullets.Length].enabled = false;
                _targetAngle += CYLINDER_ROTATION;
            }

            _isRotating = true;
        }

        public void ReloadCylinder()
        {
            // Enable all the bullets and set the rotation of the cylinder back to its original rotation.
            foreach (var b in bullets) b.enabled = true;
            _targetAngle = 30f;
            _isRotating = true;
        }

        #endregion

        #region Private Methods

        private void LerpCylinderRotation()
        {
            var eulerAngles = transform.eulerAngles;
            var currentAngle = new Vector3(
                eulerAngles.x,
                eulerAngles.y,
                Mathf.LerpAngle(eulerAngles.z, _targetAngle, Time.deltaTime * rotationSpeed)
            );
            transform.eulerAngles = currentAngle;
            if (Math.Abs(eulerAngles.z - _targetAngle) < 0.01f) _isRotating = false;
        }

        #endregion
    }
}