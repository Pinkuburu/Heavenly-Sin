using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin
{
    public class MovingPlatforms : MonoBehaviour
    {
        #region Fields
        public GameObject[] pivotPoints;
        public float platformSpeed;
        public float moveDelay;
        private int pivotCounter = 0;
        private Vector3 currentTarget;
        private float delayStart;
        #endregion

        #region LifeCycle
        private void Start()
        {
            currentTarget = pivotPoints[0].transform.position;
        }

        private void FixedUpdate()
        {
            if(transform.position != currentTarget)
            {
                Vector3 moveDir = currentTarget - transform.position;
                transform.position += (moveDir / moveDir.magnitude) * platformSpeed * Time.deltaTime;
                if(moveDir.magnitude < (platformSpeed * Time.deltaTime))
                {
                    transform.position = currentTarget;
                    delayStart = Time.time;
                }
            }
            else
            {
                if(Time.time - delayStart > moveDelay)
                {
                    pivotCounter++;
                    if(pivotCounter >= pivotPoints.Length)
                    {
                        pivotCounter = 0;
                    }
                    currentTarget = pivotPoints[pivotCounter].transform.position;
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
        #endregion
    }
}
