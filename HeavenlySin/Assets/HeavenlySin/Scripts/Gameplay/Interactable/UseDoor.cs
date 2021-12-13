using HeavenlySin.GameEvents;
using HeavenlySin.Scene.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Gameplay.Interactable
{
    public class UseDoor : MonoBehaviour, IInteractable
    {
        #region Public Fields

        [Tooltip("The index number of the image displayed when hovering over an interactable object.")]
        public int imageIndex;
        [SerializeField] private IntEvent endHover;
        [SerializeField] private IntEvent startHover;
        [SerializeField] private VoidEvent onFadeStart;
        [SerializeField] private Vector3Event onChangeScene;
        public SceneStats sceneStats;
        #endregion
    
        #region Private Fields
        private const float MAX_RANGE = 100f;
        #endregion

        #region Properties
        public float MaxRange => MAX_RANGE;
        
        #endregion

        #region Public Methods
        
        public void Interact()
        {
            onFadeStart.Raise();
            onChangeScene.Raise(sceneStats.playerPos);
            Invoke(nameof(TransitionScene), 1f);
        }

        public void OnEndHover()
        {
            endHover.Raise(imageIndex);
        }

        public void OnStartHover()
        {
            startHover.Raise(imageIndex);
        }

        public void TransitionScene()
        {
            SceneManager.LoadScene((int)sceneStats.sceneIndex);
        }
        
        #endregion

    }
}