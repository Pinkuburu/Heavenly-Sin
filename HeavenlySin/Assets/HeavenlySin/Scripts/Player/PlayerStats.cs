using HeavenlySin.GameEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Player
{
    public class PlayerStats : MonoBehaviour
    {
        #region Public Fields

        public Stats.Stats stats;
        [SerializeField] private VoidEvent onTakeDamage;
        #endregion
        
        #region PrivateFields

        private float _health;
        #endregion
 
        #region LifeCycle
        private void Awake()
        {
            _health = stats.maxHealth;
            stats.currentHealth = _health;
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
            stats.currentHealth = _health;
            onTakeDamage.Raise();
            IsDead();
        }
        
        #endregion 

        #region Private Methods

        private void IsDead()
        {
            if (_health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        #endregion
    }
}