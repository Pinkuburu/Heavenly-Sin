using HeavenlySin.GameEvents;
using UnityEngine;

namespace HeavenlySin
{
    public class BossStats : MonoBehaviour
    {
        #region Public Fields
        
        public Stats.Stats statistics;
        [SerializeField] private IntEvent enemySounds;
        public Animator anim;
        [SerializeField] private VoidEvent onLevelComplete;
        
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