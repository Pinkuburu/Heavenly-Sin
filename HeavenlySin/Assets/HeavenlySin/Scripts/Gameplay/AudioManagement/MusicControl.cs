using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HeavenlySin.GameEvents;

namespace HeavenlySin.AudioManagement
{
    public class MusicControl : MonoBehaviour
    {
        #region Fields
        public int soundIndex;
        [SerializeField] private IntEvent onPlaySound;
        #endregion

        #region LifeCycle
        private void Start()
        {
            onPlaySound.Raise(soundIndex);
        }
        #endregion
    }
}
