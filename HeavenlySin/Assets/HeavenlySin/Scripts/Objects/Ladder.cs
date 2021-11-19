using System.Linq;
using HeavenlySin.GameEvents;
using HeavenlySin.Player;
using HeavenlySin.Scene.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Objects
{
    public class Ladder : MonoBehaviour
    {
        #region Public Fields

        [SerializeField] private VoidEvent onFadeStart;
        [SerializeField] private TransformEvent onChangeScene;
        public SceneStats sceneStats;
        #endregion
        

        #region Public Methods
        
        public void TransitionScene()
        {
            SceneManager.LoadScene((int)sceneStats.sceneIndex);
        }
        
        #endregion 

        #region Private Methods

        private void OnTriggerEnter(Collider other)
        {
            var items = other.gameObject.GetComponent<PlayerScript>().inventory.items;
            foreach (var i in items.Where(i => i.itemName == "Key"))
            {
                onFadeStart.Raise();
                onChangeScene.Raise(sceneStats.playerPos.transform);
                Invoke(nameof(TransitionScene), 1f);
            }
        }

        #endregion
    }
}