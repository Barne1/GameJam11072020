using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    
    #region Singleton
    private static ObjectPool _instance;

    public static ObjectPool Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    
    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool  pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool(string nameTag, Vector3 pos, Quaternion rot)
    {
        if (!poolDictionary.ContainsKey(nameTag))
        {
            Debug.LogWarning("No pool lmao");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[nameTag].Dequeue();
        
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;
        
        poolDictionary[nameTag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
