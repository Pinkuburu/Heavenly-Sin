using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.UI
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

            if(Input.anyKeyDown)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        #endregion
    }
}