using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

namespace ShopSystem 
{
    public class SO_Data_Handler : MonoBehaviour
    {

        [Header("Meta")]
        public string persisterName;

        [Header("Scriptable Objects")]
        public List<ShopItemsScriptable> objectsToPersist;

        private void OnEnable()
        {
            for (int i = 0; i < objectsToPersist.Count; i++)
            {
                if (File.Exists(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i)))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i), FileMode.Open);
                    JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), objectsToPersist[i]);
                    file.Close();
                }
                else
                {
                    return;
                }
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < objectsToPersist.Count; i++)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i));
                var json = JsonUtility.ToJson(objectsToPersist[i]);
                bf.Serialize(file, json);
                file.Close();
            }
        }

        /*        public void Save_SO_Data()
                {
                    for (int i = 0; i < objectsToPersist.Count; i++)
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i));
                        var json = JsonUtility.ToJson(objectsToPersist[i]);
                        bf.Serialize(file, json);
                        file.Close();
                    }
                }

                public void Load_SO_Data()
                {
                    for (int i = 0; i < objectsToPersist.Count; i++)
                    {
                        if (File.Exists(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i)))
                        {
                            BinaryFormatter bf = new BinaryFormatter();
                            FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i), FileMode.Open);
                            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), objectsToPersist[i]);
                            file.Close();
                        }
                        else
                        {
                            return;
                        }
                    }
                }*/
    }
}

