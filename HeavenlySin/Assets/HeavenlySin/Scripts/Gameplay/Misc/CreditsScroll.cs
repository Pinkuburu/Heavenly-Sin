using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Gameplay
{
    public class CreditsScroll : MonoBehaviour
    {
        #region Fields
        public float scrollSpeed;
        #endregion

        #region LifeCycle
        private void Update()
        {
            transform.Translate(0, scrollSpeed, 0);

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        #endregion
    }
}
