using UnityEngine;

namespace HeavenlySin.Player
{
    public class PlayerScript : MonoBehaviour
    {
        /// <summary>
        /// PlayerScript acts as a middle-man so all of the classes below
        /// can be separated but still access the values from each other
        /// should they need to.
        /// </summary>
        public PlayerAnimation playerAnimation;
        public PlayerCollision playerCollision;
        public PlayerInput playerInput;
        public PlayerMovement playerMovement;
    }
}
