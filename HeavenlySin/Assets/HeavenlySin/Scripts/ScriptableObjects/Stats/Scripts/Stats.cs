using UnityEngine;

namespace HeavenlySin.Stats
{
    /// <summary>
    /// Variations of this script can be made for each different type of enemy
    /// so that they can easily have different maximum health values.
    /// </summary>
    [CreateAssetMenu(fileName = "New Stats", menuName = "ScriptableObjects/Stats")]
    public class Stats : ScriptableObject
    {
        public float maxHealth;
    }
}