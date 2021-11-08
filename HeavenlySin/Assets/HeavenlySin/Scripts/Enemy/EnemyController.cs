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

        #endregion

        #region LifeCycle

        private void Start()
        {
            _playerBody = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            Wander();
            PlayerDetection();

            if(isDetected)
            {
                //transform.position += _playerBody.transform.position * moveSpeed * Time.deltaTime;
            }
        }

        #endregion

        #region Public Methods
        #endregion 

        #region Private Methods

        private void Wander()
        {
            //generate a random direction with clamped max/min distances and move toward it constantly
            //enemySounds.Raise(); //Idling SFX
        }

        private void PlayerDetection()
        {
            Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectDistance);
            foreach(var hitCollider in detectedObjects)
            {
                if(hitCollider.gameObject.CompareTag("Player"))
                {
                    if (Physics.Raycast(transform.position, (hitCollider.gameObject.transform.position - transform.position), out var enemyRay, detectDistance))
                    {
                        Debug.Log("You've been detected!"); //Remove this! 
                        isDetected = true;
                        //enemySounds.Raise(); //Detected SFX
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                //Do some damage to the player
            }
        }

        #endregion
    }
}