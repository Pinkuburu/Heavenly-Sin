using System.Collections;
using UnityEngine;

namespace HeavenlySin
{
    public class crosshairShoot : MonoBehaviour
    {
        private Vector3 _targetPos;
        private float _nextTimeToFire = 0f;
        public float speed = 2.0f;
        public float shootSpeed = 3.0f;
        public float fireRate = 15f;
       
        public int maxAmmo = 6;
        private int _currentAmmo;
        public float reloadTime = 1f;
        private bool _isReloading = false;
        
        public Camera UICamera;

        private void Start()
        {
            _targetPos = transform.position;
            _currentAmmo = maxAmmo;
        }
        
        private void Update()
        {

            var distance = transform.position.z + UICamera.transform.position.z;
            _targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            _targetPos = UICamera.ScreenToWorldPoint(_targetPos);

            var followXOnly = new Vector3(_targetPos.x, _targetPos.y, transform.position.z);
            transform.position = followXOnly;
            
            if (_isReloading)
            {
                return;
            }
                

            if (_currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetMouseButtonDown(0) &&    Time.time >= _nextTimeToFire)
            {
                _nextTimeToFire = Time.time + 1f / fireRate;
                PlayerShoot();
            }
                
        }

        private IEnumerator Reload()
        {
            _isReloading = true;
            Debug.Log("Reloading...");
            yield return new WaitForSeconds(reloadTime);
            _currentAmmo = maxAmmo;
            _isReloading = false;
            /*if (Input.GetMouseButtonDown(0))
                PlayerShoot();
                */
        }

        private void PlayerShoot()
        {
            Debug.Log("Fire!");

            _currentAmmo--;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out var hit, Mathf.Infinity)){
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}

