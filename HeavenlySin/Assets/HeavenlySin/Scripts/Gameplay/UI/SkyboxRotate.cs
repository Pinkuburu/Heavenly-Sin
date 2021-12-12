using UnityEngine;

namespace HeavenlySin.Gameplay.UI
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
