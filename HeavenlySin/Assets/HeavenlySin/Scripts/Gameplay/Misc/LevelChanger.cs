using UnityEngine;

namespace HeavenlySin.Gameplay
{
    public class LevelChanger : MonoBehaviour
    {
        #region Fields

        public Animator anim;
        
        #endregion

        #region Public Methods

        // These methods will be triggered by events from other scripts

        public void OnEnable()
        {
            Time.timeScale = 1;
        }
        public void FadeToBlack()
        {
            anim.SetTrigger("FadeOut");
        }

        public void FadeFromBlack()
        {
            anim.SetTrigger("FadeIn");
        }

        #endregion 

        #region Private Methods
        #endregion
    }
}