using HeavenlySin.GameEvents;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace HeavenlySin.Interactable
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
        private DialogueSystemTrigger dialogue;
        #endregion

        #region Properties
        public float MaxRange => MAX_RANGE;

        #endregion

        #region Private Methods

        private void Start()
        {
            dialogue = GetComponent<DialogueSystemTrigger>();
        }
        #endregion

        #region Public Methods

        public void Interact()
        {
            dialogue.OnUse(this.gameObject.transform);
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