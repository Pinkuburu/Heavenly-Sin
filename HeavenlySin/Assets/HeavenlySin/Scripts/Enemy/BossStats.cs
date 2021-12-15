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
        public float health;        
        #endregion
 
        #region LifeCycle
        private void Awake()
        {
            health = statistics.maxHealth;
        }
        #endregion

        #region Public Methods
        public void TakeDamage(float damage)
        {
            health -= damage;
            healthSlider.value = (health / statistics.maxHealth);
            anim.SetTrigger("isHurt");
            //enemySounds.Raise(); //Hurt SFX
            IsDead();
        }
        #endregion 

        #region Private Methods
        private void IsDead()
        {
            if (health <= 0)
            {
                anim.SetTrigger("isDead");
                //enemySounds.Raise(); //Death SFX
                onLevelComplete.Raise();
                Destroy(gameObject, 5f);
            }
        }
        #endregion
    }
}