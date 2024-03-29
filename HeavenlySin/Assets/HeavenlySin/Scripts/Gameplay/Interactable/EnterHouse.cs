using HeavenlySin.Game;
using HeavenlySin.GameEvents;
using HeavenlySin.Objects;
using HeavenlySin.Scene.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Gameplay.Interactable
{
    public class EnterHouse : MonoBehaviour, IInteractable
    {
        #region Public Fields

        [Tooltip("The index number of the image displayed when hovering over an interactable object.")]
        public int imageIndex;
        public OpenDoor openDoor;
        public int soundIndex;
        [SerializeField] private IntEvent onPlaySound;
        [SerializeField] private IntEvent endHover;
        [SerializeField] private IntEvent startHover;
        [SerializeField] private VoidEvent onFadeStart;
        [SerializeField] private Vector3Event onChangeScene;
        public SceneStats sceneStats;
        public GameStateInfo gameState;
        
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
                onChangeScene.Raise(sceneStats.playerPos);
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
            onPlaySound.Raise(soundIndex);
            gameState.sceneIndex = sceneStats.sceneIndex;
            gameState.playerPos = sceneStats.playerPos;
            SceneManager.LoadScene((int)sceneStats.sceneIndex);
        }
        
        #endregion
    }
}