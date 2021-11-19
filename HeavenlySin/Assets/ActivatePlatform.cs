using HeavenlySin.GameEvents;
using HeavenlySin.Scene.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin
{
    public class ActivatePlatform : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private VoidEvent onFadeStart;
        [SerializeField] private TransformEvent onChangeScene;
        public SceneStats sceneStats;
        #endregion

        public void EnablePlatform()
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            onFadeStart.Raise();
            onChangeScene.Raise(sceneStats.playerPos.transform);
            Invoke(nameof(TransitionScene), 1f);
        }
        
        public void TransitionScene()
        {
            SceneManager.LoadScene((int)sceneStats.sceneIndex);
        }

        
    }
}