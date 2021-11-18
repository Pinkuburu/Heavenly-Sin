using UnityEngine;

namespace HeavenlySin
{
    public class LevelChanger : MonoBehaviour
    {
        #region Fields

        public Animator anim;
        
        #endregion
 
        #region LifeCycle
        private void Awake()
        {
        }

        private void Start()
        {
        }
 
        private void Update()
        {
        }
        #endregion

        #region Public Methods

        // These methods will be triggered by events from other scripts
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