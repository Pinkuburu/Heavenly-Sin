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
        [SerializeField] private IntEvent playerSounds;
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
            //hurt animation
            _health -= damage;
            int randNum = Random.Range(0, 3);
            playerSounds.Raise(24 + randNum); //Hurt SFX
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
                //death animation
                Destroy(this.gameObject, 3f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        #endregion
    }
}