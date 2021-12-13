using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HeavenlySin.Pages;

namespace HeavenlySin
{
    public class UpdateObjective : MonoBehaviour
    {

        // VARIABLES
        public Page page;

        public string[] objectives;
        public string hint;
        
        // Start is called before the first frame update
        void Start()
        {
            // Clear previous level's objectives
            page.ClearTestimonies();
            page.ClearRelations();
            Debug.Log("Testimonies & Relations Cleared");

            // Add in every new objective to Journal interface
            for (int i = 0; i < objectives.Length; i++)
            {
                page.AddTestimony(objectives[i]);
            }
            Debug.Log("Updated Journal with New Objectives");

            // Add in nice hint for player
            page.AddRelations(hint);
        }

        
    }
}
