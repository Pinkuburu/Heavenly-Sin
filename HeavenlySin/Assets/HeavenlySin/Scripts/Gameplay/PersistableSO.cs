using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using HeavenlySin.Game;
using UnityEngine;

namespace HeavenlySin.Gameplay
{
    public class PersistableSO : MonoBehaviour
    {
        [Header("Meta")] public string persistantName;
        [Header("Scriptable Objects")] public List<ScriptableObject> objectsToPersist;
        private GameObject _player;
        public GameStateInfo playerState;

        protected void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            const string suffix = "default";
            if (!File.Exists(Application.persistentDataPath + $"/{persistantName}_{0}_{suffix}.pso"))
            {
                Save("default");
            }
        }
        protected void OnEnable()
        {
            Load("saved");
        }

        private void Start()
        {
            if (playerState.playerPos != null && _player != null)
            {
                //_player.transform.position = playerState.playerPos;
            }
        }
        protected void OnDisable()
        {
            Save("saved");
        }

        public void ClearData(string suffix)
        {
            for (var i = 0; i < objectsToPersist.Count; i++)
            {
                File.Delete(Application.persistentDataPath + $"/{persistantName}_{i}_{suffix}.pso");
            }
            Load("default");
        }

        public void Save(string suffix)
        {
            for (var i = 0; i < objectsToPersist.Count; i++)
            {
                var bf = new BinaryFormatter();
                var file = File.Create(Application.persistentDataPath + $"/{persistantName}_{i}_{suffix}.pso");
                var json = JsonUtility.ToJson(objectsToPersist[i]);
                bf.Serialize(file, json);
                file.Close();
            }
        }

        public void Load(string suffix)
        {
            for (var i = 0; i < objectsToPersist.Count; i++)
            {
                if (File.Exists(Application.persistentDataPath + $"/{persistantName}_{i}_{suffix}.pso"))
                {
                    var bf = new BinaryFormatter();
                    var file = File.Open(
                        Application.persistentDataPath + $"/{persistantName}_{i}_{suffix}.pso",
                        FileMode.Open);
                    JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), objectsToPersist[i]);
                    file.Close();
                }
            }
        }
    }
}