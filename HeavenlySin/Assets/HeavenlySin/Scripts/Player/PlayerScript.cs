using UnityEngine;

namespace HeavenlySin.Player
{
    /// <summary>
    /// PlayerScript acts as a middle-man so all of the classes below
    /// can be separated but still access the values from each other
    /// should they need to.
    /// </summary>
    public class PlayerScript : MonoBehaviour
    {
        public Inventory.Inventory inventory;
        public PlayerAnimation playerAnimation;
        public PlayerCollision playerCollision;
        public PlayerInput playerInput;
        public PlayerMovement playerMovement;
    }
}
