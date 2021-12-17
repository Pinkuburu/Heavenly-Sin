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
            ResumeMusic();
        }
        #endregion

        #region ResumeMusic
        public void ResumeMusic()
        {
            onPlaySound.Raise(soundIndex);
        }
        #endregion
    }
}
