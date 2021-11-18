using UnityEngine;

namespace HeavenlySin.Enemy
{
    public class BossController : MonoBehaviour
    {
        #region Fields
        public float detectDistance, moveSpeed, minTravel, maxTravel, minDelay, maxDelay, spawnAmount, wanderDistance;
        public GameObject projectile;
        public GameObject enemy;
        public Transform firePoint;
        Vector3 randomPos;
        private RaycastHit _enemyRay;
        private float timeTilNextShoot;
        private float shootTimer = 0f;
        private float timeTilNextMove;
        private float moveTimer = 0f;
        Vector3 startPos;
        private bool outOfBounds = false;
        public bool isAttacking = false;
        #endregion

        #region LifeCycle
        private void Start()
        {
            timeTilNextShoot = Random.Range(minDelay, maxDelay);
            startPos = transform.position;
        }

        private void Update()
        {
            Movement();
            if(isAttacking)
            {
                
                Attack();
            }            
        }

        public void IsAttacking()
        {
            isAttacking = !isAttacking;
            Debug.Log("you're being attacked!");
        }

        private void Movement()
        {
            moveTimer += Time.deltaTime;
            if(moveTimer >= timeTilNextMove)
            {
                randomPos = new Vector3(Random.Range(minTravel, maxTravel), Random.Range(minTravel, maxTravel), Random.Range(minTravel, maxTravel));
                moveTimer = 0f;
                timeTilNextMove = Random.Range(1f, 4f);
            }

            if (outOfBounds)
            {
                transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * moveSpeed);
                outOfBounds = false;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, transform.position - randomPos, Time.deltaTime * moveSpeed);

                if (Vector3.Distance(startPos, transform.position) > wanderDistance)
                {
                    outOfBounds = true;
                }

            }
        }

        private void Attack()
        {
            Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectDistance);
            foreach(var hitCollider in detectedObjects)
            {
                if (hitCollider.gameObject.CompareTag("Player"))
                {
                    if (Physics.Raycast(transform.position, (hitCollider.gameObject.transform.position - transform.position), out _enemyRay, Mathf.Infinity))
                    {
                        shootTimer += Time.deltaTime;
                        if(shootTimer >= timeTilNextShoot)
                        {
                            GameObject projectileClone = Instantiate(projectile, firePoint.transform.position, transform.rotation);
                            shootTimer = 0f;
                            timeTilNextShoot = Random.Range(minDelay, maxDelay);
                        }
                    }
                }
            }
        }

        private void SpawnEnemies()
        {
            for(int i = 0; i < spawnAmount; i++)
            {
                GameObject EnemyClone = Instantiate(enemy, transform.position, transform.rotation);
            }
        }
        #endregion
    }
}
