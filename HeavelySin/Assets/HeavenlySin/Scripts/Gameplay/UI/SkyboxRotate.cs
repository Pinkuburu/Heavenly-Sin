using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin
{
    public class SkyboxRotate : MonoBehaviour
    {

        public float rotationSpeed;

        void Update()
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
        }
    }
}
