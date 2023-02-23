using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;
    public PoolSpawner poolSpawner;

    #region Singleton
    public static ObjectPooler instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        poolSpawner = GetComponent<PoolSpawner>();
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                newObj(pool, objectPool);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public void newObj(Pool pool, Queue<GameObject> objectPool)
    {
        GameObject obj = Instantiate(pool.prefab);
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }

}