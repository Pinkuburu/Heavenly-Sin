using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin
{
    public class MuzzleFlash : MonoBehaviour
    {
        // Start is called before the first frame update
        public ParticleSystem muzzleFlash;


        private void Start()
        {


        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                muzzleFlash.Play();
            }

        }
    }
}
