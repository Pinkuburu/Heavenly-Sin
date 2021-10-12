using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin
{
    public class ItemSpin : MonoBehaviour
    {
        #region Fields
        public float degreesPerSecond = 15.0f;
        public float amplitude = 0.5f;
        public float frequency = 1f;

        Vector3 posOffset = new Vector3();
        Vector3 tempPos = new Vector3();
        #endregion

        #region LifeCycle
        private void Awake()
        {
        }

        private void Start()
        {
            posOffset = transform.position;
        }

        private void Update()
        {   
            //Spin around the Y-axis
            transform.Rotate(new Vector3(0f, degreesPerSecond * Time.deltaTime, 0f), Space.World);

            //Float up and down
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
            transform.position = tempPos;
        }
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
