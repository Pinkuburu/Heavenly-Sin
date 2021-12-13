using HeavenlySin.Game;
using HeavenlySin.GameEvents;
using HeavenlySin.Scene.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Gameplay
{
    public class ActivatePlatform : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private VoidEvent onFadeStart;
        [SerializeField] private Vector3Event onChangeScene;
        public SceneStats sceneStats;
        public GameStateInfo gameState;
        
        #endregion

        public void EnablePlatform()
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onFadeStart.Raise();
                onChangeScene.Raise(sceneStats.playerPos);
                Invoke(nameof(TransitionScene), 1f);
            }
        }
        
        public void TransitionScene()
        {
            gameState.sceneIndex = sceneStats.sceneIndex;
            gameState.playerPos = sceneStats.playerPos;
            SceneManager.LoadScene((int)sceneStats.sceneIndex);
        }
    }
}