using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawner : MonoBehaviour
{

    private ObjectPooler objectPoolerInstance;
    private int queueSize;

    private void Start()
    {
        objectPoolerInstance = ObjectPooler.instance;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        queueSize = objectPoolerInstance.poolDictionary[tag].Count;
        if (queueSize == 0)
        {
            foreach (ObjectPooler.Pool pool in objectPoolerInstance.pools)
            {
                if (pool.tag == tag)
                {
                    objectPoolerInstance.newObj(pool, objectPoolerInstance.poolDictionary[tag]);
                }
            }
        }
        GameObject objectToSpawn = objectPoolerInstance.poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        return objectToSpawn;
    }

    public void ReturnToPool(string tag, GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objectPoolerInstance.poolDictionary[tag].Enqueue(objectToReturn);
    }
}