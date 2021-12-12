using HeavenlySin.GameEvents;
using HeavenlySin.Items;
using HeavenlySin.Player;
using UnityEngine;

namespace HeavenlySin.Gameplay.Interactable
{
    public class ItemCollection : MonoBehaviour
    {
        #region Fields
        [SerializeField] private IntEvent itemSounds;
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
            //itemSounds.Raise(11);
            Destroy(gameObject);
        }

        #endregion
    }
}