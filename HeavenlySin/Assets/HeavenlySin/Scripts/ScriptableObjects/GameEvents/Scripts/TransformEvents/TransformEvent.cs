using UnityEngine;

namespace HeavenlySin.GameEvents
{
    [CreateAssetMenu(fileName = "New Transform Event", menuName = "ScriptableObjects/GameEvent/Transform Event")]
    public class TransformEvent : BaseGameEvent<Transform> { }
}