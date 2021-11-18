using HeavenlySin.GameEvents;
using UnityEngine;

namespace HeavenlySin.Enemy
{
    /// <summary>
    /// This class handles the behavior of the enemies.
    /// Different behavior can be passed in for different enemy types.
    /// </summary>
    public class EnemyController : MonoBehaviour
    {
        #region Public Fields

        public EnemyScript enemyScript;
        public float detectDistance;
        public float moveSpeed;
        [SerializeField] private IntEvent enemySounds;

        #endregion

        #region Private Fields
        private bool isDetected = false;
        private GameObject _playerBody;
        private float timeTilNextMove;
        private float moveTimer = 0f;
        Vector3 randomPos;
        #endregion

        #region LifeCycle

        private void Start()
        {
            _playerBody = GameObject.FindGameObjectWithTag("Player");
            timeTilNextMove = Random.Range(0.5f, 1f);
        }

        private void Update()
        {
            PlayerDetection();

            if(isDetected)
            {
                //flip the sprite with direction
                if(_playerBody.transform.position.x > transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                if(_playerBody.transform.position.x < transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }

                transform.position += (_playerBody.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
            }
            else
            {
                Wander();
            }
        }

        private void Wander()
        {
            //enemySounds.Raise(); //Enemy idling SFX
            moveTimer += Time.deltaTime;
            if (moveTimer >= timeTilNextMove)
            {
                randomPos = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
                moveTimer = 0f;
                timeTilNextMove = Random.Range(0.5f, 2f);
            }

            //flip the sprite with direction
            if (randomPos.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (randomPos.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            transform.position += randomPos.normalized * moveSpeed * Time.deltaTime;
        }

        private void PlayerDetection()
        {
            Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectDistance);
            foreach (var hitCollider in detectedObjects)
            {
                if (hitCollider.gameObject.CompareTag("Player"))
                {
                    if (Physics.Raycast(transform.position, (hitCollider.gameObject.transform.position - transform.position), out var enemyRay, detectDistance))
                    {
                        isDetected = true;
                        //enemySounds.Raise(); //Detected SFX
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //Do some damage to the player
            }
        }

        #endregion
    }
}