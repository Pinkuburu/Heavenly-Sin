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

        protected void OnEnable()
        {
            for (var i = 0; i < objectsToPersist.Count; i++)
            {
                if (File.Exists(Application.persistentDataPath + $"/{persistantName}_{i}.pso"))
                {
                    var bf = new BinaryFormatter();
                    var file = File.Open(
                        Application.persistentDataPath + $"/{persistantName}_{i}.pso",
                        FileMode.Open);
                    JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), objectsToPersist[i]);
                    file.Close();
                }
            }
        }

        protected void OnDisable()
        {
            for (var i = 0; i < objectsToPersist.Count; i++)
            {
                var bf = new BinaryFormatter();
                var file = File.Create(Application.persistentDataPath + $"/{persistantName}_{i}.pso");
                var json = JsonUtility.ToJson(objectsToPersist[i]);
                bf.Serialize(file, json);
                file.Close();
            }
        }

        public void ClearData()
        {
            for (var i = 0; i < objectsToPersist.Count; i++)
            {
                File.Delete(Application.persistentDataPath + $"/{persistantName}_{i}.pso");
            }
        }
    }
}