using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin
{
    public class BossProjectile : MonoBehaviour
    {
        #region Fields
        public float projectileSpeed;
        private GameObject _player;
        private Rigidbody rb;
        #endregion

        #region LifeCycle
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            rb = GetComponent<Rigidbody>();
            rb.velocity = (_player.transform.position - transform.position).normalized * projectileSpeed;
        }

        private void Update()
        {
            Destroy(this.gameObject, 10f);
        }
        #endregion
    }
}
