using HeavenlySin.GameEvents;
using UnityEngine;

namespace HeavenlySin.Gameplay.AudioManagement
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
