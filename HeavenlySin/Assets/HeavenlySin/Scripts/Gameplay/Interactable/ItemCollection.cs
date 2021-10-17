using HeavenlySin.Items;
using HeavenlySin.Player;
using UnityEngine;

namespace HeavenlySin.Interactable
{
    public class ItemCollection : MonoBehaviour
    {
        #region Fields
        #endregion
 
        #region LifeCycle
        private void Awake()
        {
        }

        private void Start()
        {
        }
 
        private void Update()
        {
        }
        #endregion

        #region Public Methods

        public Clue clue;
        
        #endregion 

        #region Private Methods

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<PlayerScript>().inventory.AddItem(clue);
            Destroy(gameObject);
        }

        #endregion
    }
}