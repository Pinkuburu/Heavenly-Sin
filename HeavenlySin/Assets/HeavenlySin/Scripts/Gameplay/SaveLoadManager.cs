using System;
using System.Collections.Generic;
using System.IO;
using HeavenlySin.Gameplay.AudioManagement;
using HeavenlySin.Items;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeavenlySin.Gameplay
{
    public class SaveLoadManager : MonoBehaviour
    {
        private int _gameStage;
        private AudioSettingsValues _audioSettingsValues;
        public Inventory.Inventory inventory;
        public int currentScene;
        public Vector3 playerPosition;
        private void Start()
        {
            Save();
            //Load();
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("hello");
        }

        private void Update()
        {

        }

        public void Save()
        {
            var saveObject = new SaveObject
            {
                // TODO: Make these dynamic
                audioSettingsValues = new AudioSettingsValues(0.4f, 0.5f, 0.5f),
                gameStage = 0,
                // TODO: Scene and position need to come from the scriptable object.
                scene = SceneManager.GetActiveScene().buildIndex,
                position = new Vector3(1, 2.5f, 3),
                items = inventory.items
            };
            var json = JsonUtility.ToJson(saveObject);
            File.WriteAllText(Application.dataPath + "/savedata.json", json);
            Debug.Log("SAVED");
        }

        public void Load()
        {
            if (File.Exists(Application.dataPath + "/savedata.json"))
            {
                var saveString = File.ReadAllText(Application.dataPath + "/savedata.json");
                var saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                SceneManager.LoadScene(saveObject.scene);
                playerPosition = saveObject.position;
                _audioSettingsValues = new AudioSettingsValues(saveObject.audioSettingsValues);
                _gameStage = saveObject.gameStage;
                Debug.Log("LOADED");
            }
            else
            {
                Debug.Log("NO DATA FOUND");
            }
        }
    }
    
    public class SaveObject
    {
        public AudioSettingsValues audioSettingsValues;
        public int gameStage;
        public int scene;
        public Vector3 position;
        public List<Clue> items;
    }
}