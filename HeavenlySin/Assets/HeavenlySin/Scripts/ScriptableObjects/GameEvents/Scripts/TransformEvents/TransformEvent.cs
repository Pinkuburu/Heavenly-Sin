using UnityEngine;

namespace HeavenlySin.GameEvents
{
    [CreateAssetMenu(fileName = "New TransformEvent", menuName = "ScriptableObjects/GameEvent/TransformEvent")]
    public class TransformEvent : BaseGameEvent<Transform> { }
}