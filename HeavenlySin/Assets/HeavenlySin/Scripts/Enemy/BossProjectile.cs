using UnityEngine;
using Random = UnityEngine.Random;

namespace HeavenlySin.Enemy
{
    public class BossProjectile : MonoBehaviour
    {
        #region Fields

        public Stats.Stats bossStats;
        public float projectileSpeed;
        private GameObject _player;
        private Rigidbody _rb;
        #endregion

        #region LifeCycle
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _rb = GetComponent<Rigidbody>();
            _rb.velocity = (_player.transform.position - transform.position).normalized * projectileSpeed;
        }

        private void Update()
        {
            transform.Rotate(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
            Destroy(this.gameObject, 5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //Do some damage to the player
                //TODO: Connect this so the enemy stats strength
                other.GetComponent<PlayerStats>().TakeDamage(bossStats.strength);
            }
        }

        #endregion
    }
}
