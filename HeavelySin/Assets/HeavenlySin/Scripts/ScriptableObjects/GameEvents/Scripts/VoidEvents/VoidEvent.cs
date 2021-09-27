using UnityEngine;

namespace HeavenlySin.GameEvents
{
    /// <summary>
    /// Allows people to create new Void Events for objects to raise
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/Game Event/Void Event")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}
