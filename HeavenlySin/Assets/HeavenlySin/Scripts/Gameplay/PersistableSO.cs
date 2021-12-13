using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace HeavenlySin.Gameplay
{
    public class PersistableSO : MonoBehaviour
    {
        [Header("Meta")] public string persistantName;
        [Header("Scriptable Objects")] public List<ScriptableObject> objectsToPersist;

        protected void Awake()
        {
            //ClearData("default");
            //ClearData("saved");
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