using UnityEngine;

namespace HeavenlySin
{
    public class Billboard : MonoBehaviour
    {
        #region Private Fields

        private Camera _camera;

        #endregion

 
        #region LifeCycle

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0f, _camera.transform.eulerAngles.y, 0f);
        }
        #endregion
    }
}