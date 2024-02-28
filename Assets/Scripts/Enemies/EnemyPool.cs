using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public int amountToPool = 100;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject objectToPool;
        public int amountToPool = 100;
    }

    public static EnemyPool instance;
    private void Awake()
    {
        instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> pooledDictionary;

    // Start is called before the first frame update
    void Start()
    {
        pooledDictionary = new Dictionary<string, Queue<GameObject>>();
        
        Queue<GameObject> objectPool = new Queue<GameObject>();

        foreach (Pool pool in pools)
        {
            for (int i = 0; i < pool.amountToPool; i++)
            {
                GameObject obj = Instantiate(pool.objectToPool);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            pooledDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnFromPoolEnemy(string tag, Vector3 position, Quaternion rotation)
    {
        if (pooledDictionary.ContainsKey(tag))
        {
            GameObject objectToSpawn = pooledDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);

             objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            pooledDictionary[tag].Enqueue(objectToSpawn);
            return objectToSpawn;
        }
        else
        {
            Debug.Log("Pool doesnt excist " + tag);
            return null;
        }
    }
    // allow other scripts to set objects to active
    public GameObject GetPooledObjectEnemy()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
