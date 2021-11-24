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
    
    public class CrosshairShoot : MonoBehaviour
    {
        #region Public Fields
        
        public float damage;
        [Tooltip("How many times the player can fire per second.")]
        [Range(1, 5)]public float fireRate;
        public int maxAmmo = 6;
        public float reloadTime = 1f;
        public Camera UICamera;
        [SerializeField] private IntEvent gunSounds;
        [SerializeField] private IntEvent onGunFire;
        [SerializeField] private VoidEvent onGunReload;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject muzzleFlash;
        [SerializeField] private GameObject bulletTrail;
        [SerializeField] private GameObject hitFX;
        
        #endregion

        #region Private Fields

        private bool _allowFire = true;
        private int _currentAmmo;
        private bool _isReloading;
        private Vector3 _targetPos;
        private RaycastHit _rayHit;
        
        #endregion

        #region LifeCycle

        private void Start()
        {
            _targetPos = transform.position;
            _currentAmmo = maxAmmo;
        }
        
        private void Update()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
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
            
            onGunFire.Raise(_currentAmmo);
            _currentAmmo--;

            //SFX
            gunSounds.Raise(15);

            //muzzle flash FX
            var muzzleFlashClone = Instantiate(muzzleFlash, firePoint.transform.position, firePoint.transform.rotation);
            muzzleFlashClone.transform.SetParent(firePoint);
            Destroy(muzzleFlashClone, 0.025f);

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out _rayHit, Mathf.Infinity))
            {
                //bullet trail FX
                var bulletTrailClone = Instantiate(bulletTrail, firePoint.transform.position, firePoint.transform.rotation);
                LineRenderer lineR = bulletTrailClone.GetComponent<LineRenderer>();
                lineR.SetPosition(0, firePoint.transform.position);
                lineR.SetPosition(1, _rayHit.point);
                Destroy(bulletTrailClone, 1f);

                if (_rayHit.collider.gameObject.CompareTag("Enemy"))
                {
                    _rayHit.collider.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                }
                if (_rayHit.collider.gameObject.CompareTag("Boss"))
                {
                    _rayHit.collider.gameObject.GetComponent<BossStats>().TakeDamage(damage);
                }

                //ricochet FX
                if (_rayHit.collider.gameObject.CompareTag("Object"))
                {
                    var hitFXClone = Instantiate(hitFX, _rayHit.point, transform.rotation);
                    Destroy(hitFXClone, 0.5f);
                }
            }

            Invoke(nameof(AllowFire), 1/fireRate);
        }
        
        private IEnumerator Reload()
        {
            _isReloading = true;
            gunSounds.Raise(2); //Reload SFX
            yield return new WaitForSeconds(reloadTime);
            _currentAmmo = maxAmmo;
            _isReloading = false;
            onGunReload.Raise();
        }

        private void AllowFire()
        {
            _allowFire = true;
        }

        #endregion
    }
}

