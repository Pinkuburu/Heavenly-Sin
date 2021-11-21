using UnityEngine;

namespace HeavenlySin.Objects
{
    public class MovingPlatforms : MonoBehaviour
    {
        #region Fields
        public GameObject[] pivotPoints;
        public float platformSpeed;
        public float moveDelay;
        private int _pivotCounter;
        private Vector3 _currentTarget;
        private float _delayStart;
        #endregion

        #region LifeCycle
        private void Start()
        {
            _currentTarget = pivotPoints[0].transform.position;
        }

        private void FixedUpdate()
        {
            if(transform.position != _currentTarget)
            {
                var moveDir = _currentTarget - transform.position;
                transform.position += (moveDir / moveDir.magnitude) * platformSpeed * Time.deltaTime;
                if(moveDir.magnitude < (platformSpeed * Time.deltaTime))
                {
                    transform.position = _currentTarget;
                    _delayStart = Time.time;
                }
            }
            else
            {
                if(Time.time - _delayStart > moveDelay)
                {
                    _pivotCounter++;
                    if(_pivotCounter >= pivotPoints.Length)
                    {
                        _pivotCounter = 0;
                    }
                    _currentTarget = pivotPoints[_pivotCounter].transform.position;
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.SetParent(this.gameObject.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.SetParent(null);
            }
        }
        #endregion
    }
}
