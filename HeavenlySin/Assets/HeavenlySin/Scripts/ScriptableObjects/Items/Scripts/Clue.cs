using UnityEngine;
using UnityEngine.UI;

namespace HeavenlySin.Items
{
    [CreateAssetMenu(fileName = "New Clue", menuName = "ScriptableObjects/Clue")]
    public class Clue : ScriptableObject
    {
        public Image icon;
        public string itemName;
        [TextArea(15,20)] public string description;
    }
}