using UnityEngine;

namespace HeavenlySin.Game
{
    [CreateAssetMenu(fileName = "New GameState Info", menuName = "ScriptableObjects/GameStateInfo")]
    public class GameStateInfo : ScriptableObject
    {
        public Transform playerPos;
    }
}