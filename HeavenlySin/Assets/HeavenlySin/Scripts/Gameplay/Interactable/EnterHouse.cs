using HeavenlySin.GameEvents;
using HeavenlySin.Objects;
using HeavenlySin.Scene.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Interactable
{
    public class EnterHouse : MonoBehaviour, IInteractable
    {
        #region Public Fields

        [Tooltip("The index number of the image displayed when hovering over an interactable object.")]
        public int imageIndex;
        public OpenDoor openDoor;
        [SerializeField] private IntEvent endHover;
        [SerializeField] private IntEvent startHover;
        [SerializeField] private VoidEvent onFadeStart;
        [SerializeField] private TransformEvent onChangeScene;
        public SceneStats[] sceneStats;
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
            if (openDoor.isOpen)
            {
                onFadeStart.Raise();
                onChangeScene.Raise(sceneStats[0].playerPos.transform);
                Invoke(nameof(TransitionScene), 1f);
            }
        }

        public void OnEndHover()
        {
            if (openDoor.isOpen)
            {
                endHover.Raise(imageIndex);
            }
        }

        public void OnStartHover()
        {
            if (openDoor.isOpen)
            {
                startHover.Raise(imageIndex);
            }
        }
        
        public void TransitionScene()
        {
            SceneManager.LoadScene((int)sceneStats[0].sceneIndex);
        }
        
        #endregion
    }
}