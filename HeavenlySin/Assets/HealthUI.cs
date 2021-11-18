using UnityEngine;
using UnityEngine.UI;

namespace HeavenlySin
{
    public class HealthUI : MonoBehaviour
    {
        #region Fields

        public Slider slider;
        public Text healthPercent;
        public Stats.Stats playerStats;
        
        #endregion

        #region Public Methods

        public void UpdateHealthUI()
        {
            slider.value = playerStats.currentHealth / playerStats.maxHealth;
            healthPercent.text = (int)(slider.value * 100) + "%";
        }
        
        #endregion 

        #region Private Methods
        #endregion
    }
}