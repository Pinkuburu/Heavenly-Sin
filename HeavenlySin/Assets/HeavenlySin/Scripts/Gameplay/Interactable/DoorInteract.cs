using HeavenlySin.GameEvents;
using HeavenlySin.Interactable;
using UnityEngine;

namespace HeavenlySin
{
    public class DoorInteract : MonoBehaviour, IInteractable
    {
        #region Public Fields

        [Tooltip("The index number of the image displayed when hovering over an interactable object.")]
        public int imageIndex;
        [SerializeField] private IntEvent endHover;
        [SerializeField] private IntEvent startHover;
        [SerializeField] private VoidEvent onOpenAttempt;
        
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
            //Do a dialogue thing
            onOpenAttempt.Raise();
            Debug.Log("Locked");
        }

        public void OnEndHover()
        {
            endHover.Raise(imageIndex);
        }

        public void OnStartHover()
        {
            startHover.Raise(imageIndex);
        }
        
        #endregion

    }
}