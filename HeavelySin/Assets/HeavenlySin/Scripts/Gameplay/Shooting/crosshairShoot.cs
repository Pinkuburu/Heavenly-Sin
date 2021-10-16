using System.Collections;
using HeavenlySin.Enemy;
using HeavenlySin.GameEvents;
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
        [Tooltip("How many times the player can fire per second.")]
        [Range(1, 5)]public float fireRate;
        public int maxAmmo = 6;
        public float reloadTime = 1f;
        public Camera UICamera;
        [SerializeField] private IntEvent OnGunFire;
        [SerializeField] private VoidEvent OnGunReload;
        #endregion
        
        #region Private Fields
        
        private bool _allowFire = true;
        private int _currentAmmo;
        private bool _isReloading = false;
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
            var position = transform.position;
            var distance = position.z + UICamera.transform.position.z;
            _targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            _targetPos = UICamera.ScreenToWorldPoint(_targetPos);

            var followXOnly = new Vector3(_targetPos.x, _targetPos.y, position.z);
            position = followXOnly;
            transform.position = position;

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

            if (Input.GetMouseButtonDown(0) && _allowFire)
            {
                PlayerShoot();
            }
        }
        
        #endregion

        #region Private Methods
        
        private void PlayerShoot()
        {
            _allowFire = false;
            
            OnGunFire.Raise(_currentAmmo);
            _currentAmmo--;
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out var hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    hit.transform.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                }
            }
            Invoke(nameof(AllowFire), 1/fireRate);
        }
        
        private IEnumerator Reload()
        {
            _isReloading = true;
            yield return new WaitForSeconds(reloadTime);
            _currentAmmo = maxAmmo;
            _isReloading = false;
            OnGunReload.Raise();
        }

        private void AllowFire()
        {
            _allowFire = true;
        }

        #endregion
    }
}

