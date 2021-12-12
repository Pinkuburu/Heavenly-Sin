using UnityEngine;

namespace HeavenlySin.GameEvents
{
    [CreateAssetMenu(fileName = "New Transform Event", menuName = "ScriptableObjects/Game Event/Transform Event")]
    public class TransformEvent : BaseGameEvent<Transform> { }
}