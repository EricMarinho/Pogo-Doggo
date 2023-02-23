using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [SerializeField] private float destroyPosition;
    private CloudController cloudController;
    private Animation anim;
    private float speed;
    private PoolSpawner spawner;

    private void Start() {
        cloudController = GetComponentInParent<CloudController>();
        speed = Random.Range(0.5f, 1.5f);
        anim = GetComponent<Animation>();
        spawner = ObjectPooler.instance.poolSpawner;
    }

    void Update()
    {  
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x < destroyPosition){
            spawner.ReturnToPool("Cloud", gameObject);
        }
        
    }
}
