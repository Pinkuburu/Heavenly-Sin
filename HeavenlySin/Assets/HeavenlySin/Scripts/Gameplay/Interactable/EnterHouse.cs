using HeavenlySin.GameEvents;
using HeavenlySin.Interactable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin
{
    public class EnterHouse : MonoBehaviour, IInteractable
    {
        #region Public Fields

        [Tooltip("The index number of the image displayed when hovering over an interactable object.")]
        public int imageIndex;
        public OpenDoor openDoor;
        [SerializeField] private IntEvent endHover;
        [SerializeField] private IntEvent startHover;
        
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
                SceneManager.LoadScene("Dreamscape");
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
        
        #endregion
    }
}