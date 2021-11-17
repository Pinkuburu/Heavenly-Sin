using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin
{
    public class BossProjectile : MonoBehaviour
    {
        #region Fields
        #endregion

        #region LifeCycle
        private void Update()
        {
            Destroy(this.gameObject, 3f);
        }
        #endregion
    }
}
