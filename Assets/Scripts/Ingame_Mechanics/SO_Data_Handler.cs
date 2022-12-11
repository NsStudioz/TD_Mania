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

        public List<Units_Data_Handler> objectsToPersist_Final;

        //[SerializeField] int[] unitsLevelList = new int[20];

        // File Persistent Data Path Location: %AppData%\LocalLow\CompanyName\ProjectName\  (!Editor!)
        private void OnEnable()
        {
            Load_Final();
        }

        /*            for (int i = 0; i < objectsToPersist.Count; i++)
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
            }*/

        /*        private void OnDisable()
                {
                    Save_Final();
                }*/

        /*            for (int i = 0; i < objectsToPersist.Count; i++)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i));
                var json = JsonUtility.ToJson(objectsToPersist[i]);
                bf.Serialize(file, json);
                file.Close();
            }*/


        private void Save_Editor()
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

        private void Load_Editor()
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

        public void Save_Final()
        {
            for (int i = 0; i < objectsToPersist_Final.Count; i++)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i));
                var json = JsonUtility.ToJson(objectsToPersist_Final[i]);
                bf.Serialize(file, json);
                file.Close();
            }
        }

        public void Load_Final()
        {
            for (int i = 0; i < objectsToPersist_Final.Count; i++)
            {
                if (File.Exists(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i)))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open(Application.persistentDataPath + string.Format("/{0}_{1}.pso", persisterName, i), FileMode.Open);
                    JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), objectsToPersist_Final[i]);
                    file.Close();
                }
                else
                {
                    return;
                }
            }
        }

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

