using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Tooltip("This prefab will only be spawned once and persist between scenes.")]
    [SerializeField] GameObject persistentObjectPrefab = null;
    [SerializeField] GameObject persistentObjectPrefab_DataHandler = null;

    static bool hasSpawned = false;

    void Awake()
    {
        if (hasSpawned) { return; }

        SpawnPersistentObjects();

        hasSpawned = true;
    }


    private void SpawnPersistentObjects()
    {
        GameObject persistentObject = Instantiate(persistentObjectPrefab);
        GameObject persistentObject_DataHandler = Instantiate(persistentObjectPrefab_DataHandler);
        DontDestroyOnLoad(persistentObject);
        DontDestroyOnLoad(persistentObject_DataHandler);
    }

}
