using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HeavenlySin.Pages
{
    [CreateAssetMenu(fileName = "New Page", menuName = "ScriptableObjects/Page")]
    [System.Serializable]
    public class Page : ScriptableObject
    {
        //public Sprite portrait;
        public string leftPageTitle;
        public string rightPageTitle;
        public List<string> testimonies = new List<string>();
        public List<string> relations = new List<string>();

        public void AddTestimony(string testimony)
        {
            testimonies.Add(testimony);
        }

        public void AddRelations(string relation)
        {
            relations.AddRange(relation);
        }
    }
}