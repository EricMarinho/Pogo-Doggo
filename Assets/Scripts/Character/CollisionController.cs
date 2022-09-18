using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] bool isHorizontal;
    [SerializeField] float mod;
    PlayerController playerControllerInstance;
    private float groundTimer = 0f;
    private float groundTime = 0.15f;
    public bool IsOnGroundTime { get; private set; } = false;
    private void Start()
    {
        playerControllerInstance = PlayerController.Instance;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Tail")
        {
            playerControllerInstance.bounceScript.Bounce(playerControllerInstance.BounceForce);
            groundTimer = 0f;
            IsOnGroundTime = true;
        }
        else
        {
            playerControllerInstance.scoreHandler.Modifier = 0;
            playerControllerInstance.inputManager.aditionalForce = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag != "Tail"){
            if (isHorizontal)
            {
                playerControllerInstance.bounceScript.RealignHorizontal(playerControllerInstance.BounceForce * mod);
            }
            else
            {
                playerControllerInstance.bounceScript.RealignVertical(playerControllerInstance.BounceForce * mod);
            }
        }
    }

    private void Update()
    {

        if (IsOnGroundTime)
        {
            if (groundTimer < groundTime)
            {
                groundTimer += Time.deltaTime;
            }
            else
            {
                groundTimer = 0f;
                IsOnGroundTime = false;
                playerControllerInstance.inputManager.aditionalForce = 0;
                playerControllerInstance.scoreHandler.Modifier = 0;
            }
        }

        if ((playerControllerInstance.inputManager.IsBounceTime) && (IsOnGroundTime))
        {
            playerControllerInstance.inputManager.IsBounceTime = false;
            playerControllerInstance.inputManager.bounceTimer = 0f;
            IsOnGroundTime = false;
            groundTimer = 0f; 
            playerControllerInstance.scoreHandler.Modifier ++;
            playerControllerInstance.bounceScript.Bounce((playerControllerInstance.BounceForce * 2) + playerControllerInstance.inputManager.aditionalForce);
            playerControllerInstance.scoreHandler.AddScore(1*playerControllerInstance.scoreHandler.Modifier);       
        }
    }

}
