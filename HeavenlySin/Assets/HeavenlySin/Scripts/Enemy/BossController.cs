using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin
{
    public class BossController : MonoBehaviour
    {
        #region Fields
        public float detectDistance, moveSpeed, minTravel, maxTravel, minDelay, maxDelay;
        public GameObject projectile;
        Vector3 randomPos;
        private RaycastHit _enemyRay;
        private float timeTilNextShoot;
        private float shootTimer = 0f;
        private float timeTilNextMove;
        private float moveTimer = 0f;
        #endregion

        #region LifeCycle
        private void Start()
        {
            timeTilNextShoot = Random.Range(minDelay, maxDelay);
        }

        private void Update()
        {
            Movement();
            Attacking();
        }

        private void Movement()
        {
            moveTimer += Time.deltaTime;
            if(moveTimer >= timeTilNextMove)
            {
                randomPos = new Vector3(Random.Range(minTravel, maxTravel), 0, Random.Range(minTravel, maxTravel));
                moveTimer = 0f;
                timeTilNextMove = Random.Range(1f, 4f);
            }
            transform.position = Vector3.Lerp(transform.position, transform.position - randomPos, Time.deltaTime * moveSpeed);
        }

        private void Attacking()
        {
            Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectDistance);
            foreach(var hitCollider in detectedObjects)
            {
                if (hitCollider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Player has been seen by the Boss!");

                    if (Physics.Raycast(transform.position, (hitCollider.gameObject.transform.position - transform.position), out _enemyRay, Mathf.Infinity))
                    {
                        shootTimer += Time.deltaTime;
                        if(shootTimer >= timeTilNextShoot)
                        {
                            GameObject projectileClone = Instantiate(projectile, transform.position, transform.rotation);
                            shootTimer = 0f;
                            timeTilNextShoot = Random.Range(minDelay, maxDelay);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
