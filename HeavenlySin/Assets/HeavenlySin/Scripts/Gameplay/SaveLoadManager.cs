using System.Collections.Generic;
using System.IO;
using HeavenlySin.Game;
using HeavenlySin.Items;
using HeavenlySin.Scene.Scripts;
using UnityEngine;
using AudioSettings = HeavenlySin.Gameplay.AudioManagement.AudioSettings;

namespace HeavenlySin.Gameplay
{
    public class SaveLoadManager : MonoBehaviour
    {
        public static SaveLoadManager instance;
        public GameStateInfo gameStateInfo;
        private int _gameStage;
        private AudioSettings _audioSettings;
        public Inventory.Inventory inventory;

        // This keeps only one in the scene but a new one gets enabled every time we go to the main menu
        // which is where the script lives.
        private void Start()
        {
            //Save();
            DontDestroyOnLoad(this.gameObject);
            if (instance != null && instance != this)
                Destroy(this.gameObject);
            else
            {
                instance = this;
            }
        }

        private void OnEnable()
        {
            Load();
        }

        private void Update()
        {
            
        }

        public void Save()
        {
            var saveObject = new SaveObject
            {
                // TODO: Make these dynamic
                audioSettings = new AudioSettings(0.4f, 0.5f, 0.5f),
                gameStage = _gameStage,
                
                scene = (int)gameStateInfo.sceneIndex,
                position = gameStateInfo.playerPos,
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
                
                _audioSettings = new AudioSettings(saveObject.audioSettings);
                _gameStage = saveObject.gameStage;
                gameStateInfo.sceneIndex = (Scenes)saveObject.scene;
                gameStateInfo.playerPos = saveObject.position;
                inventory.items = saveObject.items;
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
        public AudioSettings audioSettings;
        public int gameStage;
        public int scene;
        public Transform position;
        public List<Clue> items;
    }
}