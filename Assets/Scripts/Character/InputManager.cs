using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] GameObject tail;
    private Animator tailAnimator;
    private Rigidbody2D rb;
    public float aditionalForce = 0f;
    public bool IsBounceTime = false;
    public float bounceTimer = 0f;
    private float bounceTime = 0.15f;
    private float forceTimer = 0f;
    private float forceTime = 0.5f;
    
    // private bool facingRight = true;

    void Start()
    {
        tailAnimator = tail.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * 240f * Time.deltaTime, Space.Self);
        // Quaternion currentRotation = gameObject.transform.localRotation;
        // if((currentRotation.z < 0) && (!facingRight)){
        //     Flip();
        // }
        // if((currentRotation.z > 0) && (facingRight)){
        //     Flip();
        // } 
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)) {
            // aumentar bounce force
            tailAnimator.SetBool("isContracting", true);
            aditionalForce += 1f;
        }

        if(Input.GetKey(KeyCode.Space)) {
            // aumentar bounce force
            if((forceTimer < forceTime) && (aditionalForce < 5f)) {
                aditionalForce += Time.deltaTime * 1f;
                forceTimer += Time.deltaTime;
                Debug.Log(aditionalForce);
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            // fall faster
            PlayerController.Instance.bounceScript.Fall(PlayerController.Instance.FallForce);
        }
     
        if(Input.GetKeyUp(KeyCode.Space)){
            
            IsBounceTime = true;
            forceTimer = 0;
            tailAnimator.SetBool("isContracting", false);
        }

        if(IsBounceTime){
            if(bounceTimer < bounceTime){
                bounceTimer += Time.deltaTime;
            }
            else{
                bounceTimer = 0;
                IsBounceTime = false;
            }
        }

    }

    // void Flip(){
    //     Vector3 currentScale = gameObject.transform.localScale;
    //     currentScale.x *= -1;
    //     gameObject.transform.localScale = currentScale;

    //     facingRight = !facingRight;
    // }

}
