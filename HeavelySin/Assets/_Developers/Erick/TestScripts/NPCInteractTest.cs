using HeavenlySin.Interactable;
using UnityEngine;

namespace HeavenlySin
{
    public class NPCInteractTest : MonoBehaviour, IInteractable
    {
        #region Private Fields
        private const float MAX_RANGE = 100f;
        #endregion

        #region Properties
        public float MaxRange => MAX_RANGE;
        #endregion
        
        #region Public Methods
        public void Interact()
        {
            Debug.Log("Hello, World!");
        }

        public void OnEndHover()
        {
            Debug.Log("EndHover");
        }

        public void OnStartHover()
        {
            Debug.Log("Hover");
        }
        #endregion
    }
}
