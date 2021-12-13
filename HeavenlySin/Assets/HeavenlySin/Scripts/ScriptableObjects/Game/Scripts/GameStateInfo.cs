using HeavenlySin.Scene.Scripts;
using UnityEngine;

namespace HeavenlySin.Game
{
    [CreateAssetMenu(fileName = "New GameState Info", menuName = "ScriptableObjects/GameStateInfo")]
    [System.Serializable]
    public class GameStateInfo : ScriptableObject
    {
        public Transform playerPos;
        public Scenes sceneIndex;
    }
}