using HeavenlySin.GameEvents;
using UnityEngine;
using UnityEngine.UI;

namespace HeavenlySin.Enemy
{
    /// <summary>
    /// This class handles the enemy's health and damage dealing.
    /// </summary>
    public class EnemyStats : MonoBehaviour
    {
        #region Public Fields
        
        public Stats.Stats statistics;
        [SerializeField] private IntEvent enemySounds;
        public Slider healthSlider;
        public Animator anim;

        #endregion

        #region

        private float _health;
        
        #endregion
 
        #region LifeCycle
        private void Awake()
        {
            _health = statistics.maxHealth;
        }

        #endregion

        #region Public Methods

        public void TakeDamage(float damage)
        {
            _health -= damage;
            healthSlider.value = (_health / statistics.maxHealth);
            anim.SetTrigger("isHurt");
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
                Destroy(gameObject, 0.25f);
            }
        }
        
        #endregion
    }
}