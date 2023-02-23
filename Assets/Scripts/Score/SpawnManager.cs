using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    private Vector2 min = new Vector2(0, 0);
    private Vector2 max = new Vector2(0, 0);
    private Vector2 pos;
    [SerializeField] private PoolSpawner poolSpawner;

    // Start is called before the first frame update
    void Start()
    {
        SetMinMax();
        SpawnBone();
    }

    private void SetMinMax(){
        min = new Vector2(-20f,-2f);
        max = new Vector2(0.4f, 3f);
        
    }

    public void SpawnBone(){
        pos = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        GameObject boneObject = poolSpawner.SpawnFromPool("Bone", pos, Quaternion.identity);
    }
}
