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
    private Rigidbody2D rb;

    private void Start()
    {
        playerControllerInstance = PlayerController.Instance;
        rb = playerControllerInstance.GetComponent<Rigidbody2D>();
    }
    
     private void Update()
    {
        
        // if(rb.velocity.y < 0){
            // playerControllerInstance.doggoAnimationHandler.SetJumping(false);
        // }
        // else{
        //     animator.SetBool("isJumping", true);
        // }


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
                playerControllerInstance.scoreHandler.ResetModifier();
            }
        }

        if ((playerControllerInstance.inputManager.IsBounceTime) && (IsOnGroundTime))
        {
            playerControllerInstance.inputManager.IsBounceTime = false;
            playerControllerInstance.inputManager.bounceTimer = 0f;
            IsOnGroundTime = false;
            groundTimer = 0f; 
            playerControllerInstance.scoreHandler.IncreaseModifier();
            playerControllerInstance.bounceScript.Bounce((playerControllerInstance.BounceForce * 2) + playerControllerInstance.inputManager.aditionalForce);
            playerControllerInstance.tricksScoreManager.SetStunt(true);
            playerControllerInstance.scoreHandler.AddScore(1*playerControllerInstance.scoreHandler.Modifier);
            // playerControllerInstance.doggoAnimationHandler.SetJumping(true);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Tail")
        {
            playerControllerInstance.bounceScript.Bounce(playerControllerInstance.BounceForce);
            groundTimer = 0f;
            IsOnGroundTime = true;
            playerControllerInstance.characterSounds.PlayJumpSound();
        }
        else
        {
            if(transform.position.y < -4.3f){
                playerControllerInstance.scoreHandler.ResetModifier();
                playerControllerInstance.inputManager.aditionalForce = 0;
            }
            playerControllerInstance.characterSounds.PlayFallSound();
        }
        PlayerController.Instance.tricksScoreManager.SetStunt(false);
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

}
