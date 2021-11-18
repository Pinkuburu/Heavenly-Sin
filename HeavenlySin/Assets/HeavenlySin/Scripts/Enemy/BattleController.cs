using HeavenlySin.GameEvents;
using UnityEngine;

namespace HeavenlySin.Enemy
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private VoidEvent onPlatform;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onPlatform.Raise();
            }
        }

        /*private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onPlatform.Raise();
            }
        }*/
    }
}