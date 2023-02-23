using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudStageController : MonoBehaviour
{
    private float timer = 0f;
    private float time = 0f;
    private PoolSpawner poolSpawner;

    private void Start()
    {
        poolSpawner = ObjectPooler.instance.poolSpawner;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer < time){
            timer += Time.deltaTime;
        }
        else{
            timer = 0f;
            time = Random.Range(3f, 5f);
            SpawnCloud();
        }

    }

    public void SpawnCloud()
    {
        GameObject cloud = poolSpawner.SpawnFromPool("Cloud", transform.position, Quaternion.identity);
        cloud.transform.parent = transform;
        Vector2 randomPosition = new Vector2(10f, Random.Range(-1f, 4f));
        float randomSize = Random.Range(1f, 2f);
        cloud.transform.localPosition = randomPosition;
        cloud.transform.localScale = new Vector3(randomSize, randomSize, 1f);
    }
}
