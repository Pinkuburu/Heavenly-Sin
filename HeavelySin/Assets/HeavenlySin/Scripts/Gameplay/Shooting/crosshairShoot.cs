using System.Collections;
using HeavenlySin.Enemy;
using UnityEngine;

namespace HeavenlySin.Shooting
{
    /// <summary>
    /// This class handles the moving of the player's crosshair
    /// as well as the shooting and reloading mechanics
    /// </summary>
    
    // TODO: Rename this class to CrosshairShoot and rename the file. 
    public class crosshairShoot : MonoBehaviour
    {
        #region Public Fields
        
        public float damage;
        public float fireRate = 15f;
        public int maxAmmo = 6;
        public float reloadTime = 1f;
        public Camera UICamera;
        
        #endregion
        
        #region Private Fields
        
        private int _currentAmmo;
        private bool _isReloading = false;
        private float _nextTimeToFire = 0f;
        private Vector3 _targetPos;
        
        #endregion
        
        #region LifeCycle
        
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

            if (Input.GetMouseButtonDown(0) && Time.time >= _nextTimeToFire)
            {
                _nextTimeToFire = Time.time + 1f / fireRate;
                PlayerShoot();
            }
        }
        
        #endregion

        #region Private Methods
        
        private void PlayerShoot()
        {
            Debug.Log("Fire!");

            _currentAmmo--;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out var hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    hit.transform.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                }
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
        
        #endregion
    }
}

