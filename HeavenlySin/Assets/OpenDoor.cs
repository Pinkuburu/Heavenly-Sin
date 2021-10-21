using HeavenlySin.GameEvents;
using UnityEngine;

namespace HeavenlySin
{
    public class OpenDoor : MonoBehaviour
    {
        #region Public Fields

        public Sprite sprite;

        #endregion
        
        #region Private Fields

        private SpriteRenderer _renderer;
        public bool isOpen;
        #endregion
        
 
        #region LifeCycle
        private void Awake()
        {
        }

        private void Start()
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
        }
 
        private void Update()
        {
        }
        #endregion

        #region Public Methods

        public void OpenDoorSprite()
        {
            _renderer.sprite = sprite;
            isOpen = true;
        }
        
        #endregion 

        #region Private Methods
        #endregion
    }
}