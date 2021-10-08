using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin
{
    public class crosshairShoot : MonoBehaviour
    {
        private Vector3 targetPos;
        private float nextTimeToFire = 0f;
        public float speed = 2.0f;
        public float shootSpeed = 3.0f;
        public float fireRate = 15f;
       
        public int maxAmmo = 6;
        private int currentAmmo;
        public float reloadTime = 1f;
        private bool isReloading = false;
        
        public Rigidbody Projectile;
        public Camera UIcamera;

        void Start()
        {
            targetPos = transform.position;
            currentAmmo = maxAmmo;

        }
        
        void Update()
        {

            float distance = transform.position.z + UIcamera.transform.position.z;
            targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            targetPos = UIcamera.ScreenToWorldPoint(targetPos);

            Vector3 followXonly = new Vector3(targetPos.x, targetPos.y, transform.position.z);
            transform.position = followXonly;

            if (isReloading)
            {
                return;
            }
                

            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetMouseButtonDown(0) &&    Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                PlayerShoot();
                
            }
                
        }

        IEnumerator Reload()
        {
            isReloading = true;
            Debug.Log("Reloading...");
            yield return new WaitForSeconds(reloadTime);
            currentAmmo = maxAmmo;
            isReloading = false;
        }

        void PlayerShoot()
        {
            Debug.Log("Fire!");

            currentAmmo--;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity)){
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}

