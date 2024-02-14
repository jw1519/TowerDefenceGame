using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileObjectPool : MonoBehaviour
//creates projectiles efore the game runs 
{
    //public static ObjectPool pool;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool = 10;

    

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject objectToPool;
        public int amountToPool = 10;
    }
    //singleton
    public static ProjectileObjectPool instance;

    private void Awake()
    {
        instance = this;
    }


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> pooledDictionary;

    void Start()
    {
        pooledDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.amountToPool; i++)
            {
                GameObject obj = Instantiate(pool.objectToPool);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            pooledDictionary.Add(pool.tag, objectPool);
        }


        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++) //adds to pool then sets them as inactive
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    //spawn
    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if (pooledDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool doesnt excist " + tag);
            return null;
        }

        GameObject objectToSpawn = pooledDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        pooledDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }


    // allow other scripts to set objects to active
    public GameObject GetPooledObject()
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
