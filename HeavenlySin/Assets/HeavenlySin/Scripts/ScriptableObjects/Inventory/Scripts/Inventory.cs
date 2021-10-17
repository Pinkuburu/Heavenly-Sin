using System.Collections.Generic;
using HeavenlySin.Items;
using UnityEngine;

namespace HeavenlySin.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "ScriptableObjects/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField] public List<Clue> items = new List<Clue>();

        public void AddItem(Clue clue)
        {
            items.Add(clue);
        }
    }
}