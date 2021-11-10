using HeavenlySin.GameEvents;
using UnityEngine;

namespace HeavenlySin.Enemy
{
    /// <summary>
    /// This class handles the enemy's health and damage dealing.
    /// </summary>
    public class EnemyStats : MonoBehaviour
    {
        #region Public Fields

        public EnemyScript enemyScript;
        public Stats.Stats stats;
        [SerializeField] private IntEvent enemySounds;

        #endregion

        #region

        private float _health;
        
        #endregion
 
        #region LifeCycle
        private void Awake()
        {
            _health = stats.maxHealth;
        }

        private void Start()
        {
        }
 
        private void Update()
        {
        }
        #endregion

        #region Public Methods

        public void TakeDamage(float damage)
        {
            _health -= damage;
            //enemySounds.Raise(); //Hurt SFX
            IsDead();
            // TODO: update UI health bar.
        }
        
        #endregion 

        #region Private Methods

        private void IsDead()
        {
            if (_health <= 0)
            {
                //enemySounds.Raise(); //Death SFX
                Destroy(gameObject);
            }
        }
        
        #endregion
    }
}