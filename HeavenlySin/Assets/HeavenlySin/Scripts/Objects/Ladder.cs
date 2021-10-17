using System.Linq;
using HeavenlySin.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Objects
{
    public class Ladder : MonoBehaviour
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
        #endregion 

        #region Private Methods

        private void OnTriggerEnter(Collider other)
        {
            var items = other.gameObject.GetComponent<PlayerScript>().inventory.items;
            foreach (var i in items.Where(i => i.itemName == "Key"))
            {
                SceneManager.LoadScene("Overworld");
            }
        }

        #endregion
    }
}