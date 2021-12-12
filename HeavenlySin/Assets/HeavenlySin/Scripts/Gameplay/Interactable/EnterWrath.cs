using HeavenlySin.GameEvents;
using HeavenlySin.Scene.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Gameplay.Interactable
{
    public class EnterWrath : MonoBehaviour, IInteractable
    {
        #region Public Fields

        [Tooltip("The index number of the image displayed when hovering over an interactable object.")]
        public int imageIndex;
        [SerializeField] private IntEvent endHover;
        [SerializeField] private IntEvent onPlaySound;
        [SerializeField] private VoidEvent onFadeStart;
        [SerializeField] private VoidEvent onFadeEnd;
        [SerializeField] private IntEvent startHover;
        [SerializeField] private TransformEvent onChangeScene;
        public SceneStats sceneStats;

        public GameObject wrath;
        #endregion
    
        #region Private Fields
        private const float MAX_RANGE = 100f;
        private bool _enterWrath;
        #endregion

        #region Properties
        public float MaxRange => MAX_RANGE;
        
        #endregion

        #region Public Methods
        
        public void Interact()
        {
            onFadeStart.Raise();
            if (!_enterWrath)
            {
                _enterWrath = true;
                Invoke(nameof(EnableWrath), 1f);
            }
            else
            {
                // Set the transform the player should end up a
                onChangeScene.Raise(sceneStats.playerPos.transform);
                Invoke(nameof(TransitionScene), 1f);
            }
            //onPlaySound.Raise(0);
        }

        public void OnEndHover()
        {
            endHover.Raise(imageIndex);
        }

        public void OnStartHover()
        {
            startHover.Raise(imageIndex);
        }

        public void EnableWrath()
        {
            // Enable wrath and whatever.
            onFadeEnd.Raise();
            wrath.SetActive(true);
        }

        public void TransitionScene()
        {
            SceneManager.LoadScene((int)sceneStats.sceneIndex);
        }
        
        #endregion

    }
}