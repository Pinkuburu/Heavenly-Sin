using PixelCrushers.DialogueSystem.Demo;
using UnityEngine;

namespace HeavenlySin.Enemy
{
    /// <summary>
    /// This class handles the enemy's health and damage dealing.
    /// </summary>
    public class EnemyStats : MonoBehaviour
    {
        #region Fields

        public EnemyScript enemyScript;
        public Stats.Stats stats;

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
            IsDead();
            // TODO: update UI health bar.
        }
        
        #endregion 

        #region Private Methods

        private void IsDead()
        {
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        #endregion
    }
}