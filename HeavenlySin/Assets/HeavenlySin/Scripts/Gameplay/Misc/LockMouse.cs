using UnityEngine;

namespace HeavenlySin.Gameplay
{
    public class LockMouse : MonoBehaviour
    {
        #region Fields

        #endregion

        #region LifeCycle

        private void Awake() { }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        #endregion
    }
}