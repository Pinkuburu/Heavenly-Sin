using UnityEngine;

namespace HeavenlySin.Scene.Scripts
{
    [CreateAssetMenu(fileName = "New Spawn", menuName = "ScriptableObjects/Spawn")]
    public class Spawn : ScriptableObject
    {
        public Vector3 spawnPos;
        public GameObject prefab;
    }
}