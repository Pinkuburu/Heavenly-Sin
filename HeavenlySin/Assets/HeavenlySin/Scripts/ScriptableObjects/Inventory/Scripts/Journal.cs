using System.Collections.Generic;
using HeavenlySin.Pages;
using UnityEngine;

namespace HeavenlySin.Inventory
{
    [CreateAssetMenu(fileName = "New Journal", menuName = "ScriptableObjects/Journal")]
    public class Journal : ScriptableObject
    {
        public Page[] pages;
    }
}