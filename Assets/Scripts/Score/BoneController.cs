using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneController : MonoBehaviour
{
    private float timer = 0f;
    private float time = 10f;
    private PlayerController instance;
    
    private void Start()
    {
        instance = PlayerController.Instance;
    }

     private void Update()
    {
        if (timer < time)
        {
            timer += Time.deltaTime;
        }
        else
        {
            instance.spawnManager.SpawnBone();
            Object.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            instance.characterSounds.PlayPickBonesSound();
            instance.scoreHandler.AddScore(150 * instance.scoreHandler.Modifier);
            instance.spawnManager.SpawnBone();
            Object.Destroy(gameObject);
        }
    }

   

}
