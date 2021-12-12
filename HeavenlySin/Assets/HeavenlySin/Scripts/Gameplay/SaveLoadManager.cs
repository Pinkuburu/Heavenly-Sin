using System.IO;
using HeavenlySin.Game;
using HeavenlySin.Scene.Scripts;
using UnityEngine;

namespace HeavenlySin.Gameplay
{
    public class SaveLoadManager : MonoBehaviour
    {
        private static SaveLoadManager _Instance;
        public GameStateInfo gameStateInfo;
        private int _gameStage;

        // This keeps only one in the scene but a new one gets enabled every time we go to the main menu
        // which is where the script lives.

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            if (_Instance != null && _Instance != this)
                Destroy(this.gameObject);
            else
            {
                _Instance = this;
            }
        }

        private void OnEnable()
        {
            Load();
        }

        public void Save()
        {
            var saveObject = new SaveObject
            {
                // TODO: Make these dynamic
                gameStage = _gameStage,
                
                scene = (int)gameStateInfo.sceneIndex,
                position = gameStateInfo.playerPos,
            };
            var json = JsonUtility.ToJson(saveObject);
            File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
            Debug.Log("SAVED");
        }

        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/savedata.json"))
            {
                var saveString = File.ReadAllText(Application.persistentDataPath + "/savedata.json");
                var saveObject = JsonUtility.FromJson<SaveObject>(saveString);
                
                _gameStage = saveObject.gameStage;
                gameStateInfo.sceneIndex = (Scenes)saveObject.scene;
                if (saveObject.scene == 0)
                {
                    gameStateInfo.sceneIndex = Scenes.OFFICE;
                }
                gameStateInfo.playerPos = saveObject.position;
                Debug.Log("LOADED");
            }
            else
            {
                Debug.Log("NO DATA FOUND");
            }
        }

        public void FreshLoad()
        {
            _gameStage = 0;
            gameStateInfo.sceneIndex = Scenes.OFFICE;
            gameStateInfo.playerPos = null;
            Debug.Log("LOADED FRESH GAME DATA");
        }
    }
    
    public class SaveObject
    {
        public int gameStage;
        public int scene;
        public Transform position;
    }
}