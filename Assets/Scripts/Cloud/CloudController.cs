using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private float timer = 0f;
    private float time = 0f;
    [SerializeField] GameObject cloudPrefab;

    // Update is called once per frame
    void Update()
    {
        if (timer < time){
            timer += Time.deltaTime;
        }
        else{
            timer = 0f;
            time = Random.Range(1f, 3f);
            SpawnCloud();
        }

    }

    public void SpawnCloud()
    {
        GameObject cloud = Instantiate(cloudPrefab, transform);
        Vector2 randomPosition = new Vector2(380f, Random.Range(-350f, 450f));
        float randomSize = Random.Range(1f, 2f);
        cloud.transform.localPosition = randomPosition;
        cloud.transform.localScale = new Vector3(randomSize, randomSize, 1f);
    }
}
