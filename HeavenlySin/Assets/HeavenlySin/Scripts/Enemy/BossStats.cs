using HeavenlySin.GameEvents;
using UnityEngine;
using UnityEngine.UI;

namespace HeavenlySin.Enemy
{
    public class BossStats : MonoBehaviour
    {
        #region Public Fields
        
        public Animator anim;
        public Stats.Stats statistics;
        [SerializeField] private IntEvent enemySounds;
        [SerializeField] private VoidEvent onLevelComplete;
        public Slider healthSlider;
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
                onLevelComplete.Raise();
                Destroy(gameObject, 0.25f);
            }
        }
        #endregion
    }
}