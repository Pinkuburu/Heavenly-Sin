using HeavenlySin.GameEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin
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