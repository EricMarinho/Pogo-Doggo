using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private CloudController cloudController;
    private Animation anim;
    private float speed;

    private void Start() {
        cloudController = GetComponentInParent<CloudController>();
        speed = Random.Range(0.5f, 1.5f);
        anim = GetComponent<Animation>();
    }

    void Update()
    {  
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x < -12f){
            Debug.Log("Cloud Destroyed");
            Object.Destroy(gameObject);
        }
        
    }
}
