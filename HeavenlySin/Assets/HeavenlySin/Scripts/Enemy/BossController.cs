using UnityEngine;

namespace HeavenlySin.Enemy
{
    public class BossController : MonoBehaviour
    {
        #region Fields
        public BossStats bossStats;
        public float detectDistance, moveSpeed, minTravel, maxTravel, minDelay, maxDelay, spawnAmount, wanderDistance;
        public GameObject projectile;
        public GameObject enemy;
        public Transform firePoint;
        private Vector3 _randomPos;
        private RaycastHit _enemyRay;
        private float _timeTilNextShoot;
        private float _shootTimer;
        private float _timeTilNextMove;
        private float _moveTimer;
        private Vector3 _startPos;
        private bool _outOfBounds;
        public bool isAttacking;
        #endregion

        #region LifeCycle
        private void Start()
        {
            _timeTilNextShoot = Random.Range(minDelay, maxDelay);
            _startPos = transform.position;
        }

        private void Update()
        {
            Movement();
            if(isAttacking && bossStats.health > 0)
            {
                Attack();
            }            
        }

        public void IsAttacking()
        {
            isAttacking = !isAttacking;
        }

        private void Movement()
        {
            _moveTimer += Time.deltaTime;
            if(_moveTimer >= _timeTilNextMove)
            {
                _randomPos = new Vector3(Random.Range(minTravel, maxTravel), Random.Range(minTravel, maxTravel), Random.Range(minTravel, maxTravel));
                _moveTimer = 0f;
                _timeTilNextMove = Random.Range(1f, 4f);
            }

            if (_outOfBounds)
            {
                transform.position = Vector3.Lerp(transform.position, _startPos, Time.deltaTime * moveSpeed);
                _outOfBounds = false;
            }
            else
            {
                var position = transform.position;
                position = Vector3.Lerp(position, position - _randomPos, Time.deltaTime * moveSpeed);
                transform.position = position;

                if (Vector3.Distance(_startPos, transform.position) > wanderDistance)
                {
                    _outOfBounds = true;
                }
            }
        }

        private void Attack()
        {
            var detectedObjects = Physics.OverlapSphere(transform.position, detectDistance);
            foreach(var hitCollider in detectedObjects)
            {
                if (hitCollider.gameObject.CompareTag("Player"))
                {
                    if (Physics.Raycast(transform.position, (hitCollider.gameObject.transform.position - transform.position), out _enemyRay, Mathf.Infinity))
                    {
                        _shootTimer += Time.deltaTime;
                        if(_shootTimer >= _timeTilNextShoot)
                        {
                            var projectileClone = Instantiate(projectile, firePoint.transform.position, transform.rotation);
                            _shootTimer = 0f;
                            _timeTilNextShoot = Random.Range(minDelay, maxDelay);
                        }
                    }
                }
            }
        }

        private void SpawnEnemies()
        {
            for(var i = 0; i < spawnAmount; i++)
            {
                var enemyClone = Instantiate(enemy, transform.position, transform.rotation);
            }
        }
        #endregion
    }
}
