using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin
{
    public class ReloadLevel : MonoBehaviour
    {
        #region Fields
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
        #endregion 

        #region Private Methods

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                ReloadScene();
            }
        }

        private static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion
    }
}