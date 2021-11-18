using HeavenlySin.GameEvents;
using UnityEngine;

namespace HeavenlySin.Interactable
{
    public class EnterWrath : MonoBehaviour, IInteractable
    {
        #region Public Fields

        [Tooltip("The index number of the image displayed when hovering over an interactable object.")]
        public int imageIndex;
        [SerializeField] private IntEvent endHover;
        [SerializeField] private IntEvent startHover;
        [SerializeField] private IntEvent onPlaySound;
        [SerializeField] private VoidEvent onFadeStart;
        [SerializeField] private VoidEvent onFadeEnd;
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
            Invoke(nameof(EnableWrath), 1f);
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
        }
        
        #endregion

    }
}